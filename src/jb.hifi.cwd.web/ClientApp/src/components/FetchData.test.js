import React from 'react';
import { rest } from 'msw';
import { setupServer } from 'msw/node';
import { render, fireEvent, waitFor, screen } from '@testing-library/react';
import '@testing-library/jest-dom';
import { FetchData } from './FetchData';

const server = setupServer(
    rest.get('/currentweatherdata', (req, res, ctx) => {
        return res(ctx.json({
            description: 'cloudy',
            success: true,
            errors:[]
        }))
    }),
)

beforeAll(() => server.listen())
afterEach(() => server.resetHandlers())
afterAll(() => server.close())

test('loads weather page and displays initial populated data', async () => {
    render(<FetchData url="/fetch-data" />);
    var description = await waitFor(() => screen.getByTestId('staticDescription'));

    // moment of truth!
    expect(description).toHaveTextContent('cloudy');
})

test('weather page handles server error', async () => {
    server.use(
        rest.get('/currentweatherdata', (req, res, ctx) => {
            return res(ctx.status(500));
        }),
    );

    render(<FetchData url="/fetch-data" />);
    fireEvent.click(screen.getByTestId('btnWeatherDataRefresh'));
    var errorField = await waitFor(() => screen.getByTestId('staticError'));

    expect(errorField).toHaveTextContent('Internal Server Error');
})

test('weather page handles rate limiting error', async () => {
    server.use(
        rest.get('/currentweatherdata', (req, res, ctx) => {
            return res(ctx.status(429));
        }),
    );

    render(<FetchData url="/fetch-data" />);
    fireEvent.click(screen.getByTestId('btnWeatherDataRefresh'));
    var errorField = await waitFor(() => screen.getByTestId('staticError'));

    expect(errorField).toHaveTextContent('Too Many Requests');
})