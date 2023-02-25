import React from 'react';
import { render, fireEvent, waitFor, screen } from '@testing-library/react';
import '@testing-library/jest-dom';
import { Home } from './Home';

test('loads home page and displays greeting', async () => {
    render(<Home />);
    var header = await waitFor(() => screen.getByRole('heading'));

    // moment of truth!
    expect(header).toHaveTextContent('Hello, JB HiFi team!');
})