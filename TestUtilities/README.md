## Test Utilities

Reusable helper utilities for my Selenium test projects using .NET, designed to simplify automation and promote code reuse and maintainability.

## Description

This project provides a set of helper classes to simplify Selenium test automation, including:

- WebDriver management
- Custom waits
- Screenshot capturing
- Report generation (using ExtentReports)
- Test result logging
- Configuration management via appsettings.json

These utilities are designed to be shared across multiple test projects, promoting code reuse and maintainability.

## Features

- 'WebDriverFactory' - Create, get, and close WebDriver instance easily.
- 'WebDriverWaitHelper' - Centralized custom wait methods.
- 'ScreenshotHelper' - Capture screenshots for reports. 
- 'ReportManager' - Generate, and log test reports.
- 'TestResultHelper' - Log test results and status.
- 'ConfigReader' – Load configuration settings from appsettings.json

## Getting Started

To use these utility helper class:

1. Go to your test project
2. Right click, go to 'Add'
3. Click 'Project reference'
4. In the reference manager window, select TestUtilities project
5. Click 'Ok'

## Tech Stack

- Selenium WebDriver
- C# (.Net)
- NUnit 3
- JSON
- Git/Github

## Author

- John Levi P. Barcenas - [@Jhnlevi](https://github.com/Jhnlevi)