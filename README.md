# Homey Variable Debugger

This application is written to make debugging homey variables easy.

The application listens on port 8090 (or an other one configurable in app.config). It expects a json post on the root URL with the following structure:

{"Key":"Variable 1", "Value":"This is a variable"}
