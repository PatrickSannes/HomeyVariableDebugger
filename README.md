# Homey Variable Debugger

This application is written to make debugging homey variables easy.

To get started:
- In the app.config change the Address value to your pc's address
- Allow the application trough the firewall
- Run the application as administrator (else windows dont allow to setup a web host)

Send a json post on the root URL with the following structure:

{"Key":"Variable 1", "Value":"This is a variable"}
