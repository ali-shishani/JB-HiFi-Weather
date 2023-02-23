# JB-HiFi-Weather

This project was bootstrapped with [Create React App](https://github.com/facebookincubator/create-react-app).

Below you will find some information on how to perform common tasks.<br>
You can find the most recent version of this guide [here](https://github.com/facebookincubator/create-react-app/blob/master/packages/react-scripts/template/README.md).

### Key Features in the solution
* React app located in the ClientApp folder - [Create React App](https://github.com/facebookincubator/create-react-app).
* WebApi available to service the front-end React app. The WebApi have a REST URL that accepts both a city name and country name
* Rate Limition - 5 requests per hour maximum limit - client id or can support ip address.
* Integration with Open Weather API and providing weather description of the specified city and country.

### Running the solution

Follow these steps:

* Install Visual Studio 2022.
* Install NodeJs.
* Clone the repo.
* Restore All new packages in Visual Studio.
* Make sure that the web project is the start-up project.
* Click Run to start the app.

### Running Unit Test - React - Command Line Interface

When you run `npm test`, Jest will launch in the watch mode. Every time you save a file, it will re-run the tests, just like `npm start` recompiles the code.

The watcher includes an interactive command-line interface with the ability to run all tests, or focus on a search pattern. It is designed this way so that you can keep it open and enjoy fast re-runs. You can learn the commands from the “Watch Usage” note that the watcher prints after every run:

![Jest watch mode](http://facebook.github.io/jest/img/blog/15-watch.gif)

### Running Unit Test - Back End

TBA

