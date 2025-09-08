## OrangeHRM Automation Project

A beginner level automation project using Selenium WebDriver to test the OrangeHRM demo website. This project focuses on learning automation basics while testing important HRM features.

## Description

This is my second beginner project that automates some key tasks in the OrangeHRM demo site, such as logging in, managing employees, users, leaves, and profiles, and checking the dashboard.

It’s designed to practice:
- Writing simple automated tests using Selenium and Page Object Model (POM).
- Using data driven testing (DDT) to run multiple scenarios.
- Taking screenshots and creating simple test reports.
- Managing configuration settings using appsettings.json.

It’s a learning project, so the focus is on understanding automation concepts and building reusable helpers for practice.

## Features

- UI Testing with Selenium & POM: Organize page objects for easier test scripts.
- Data Driven Testing (DDT): Use JSON files to test multiple scenarios.
- Custom Waits: Waits for elements to make tests more stable.
- Driver Factory: Open tests in different browsers.
- Config Settings: Use appsettings.json for URLs, usernames, and passwords.
- Screenshots & Reports: Save screenshots when tests fail and make simple reports.
- CI Basics: Setup to run tests automatically in a simple pipeline.

## Getting Started

Steps to run the project locally:

1. Clone the repository:
   ```bash
   git clone https://github.com/Jhnlevi/selenium-web-automation-1.git
   ```
2. Open the solution in Visual Studio.
3. Restore NuGet packages.
4. Configure appsettings.json (browser, URL) if necessary.
5. Run tests using Test Explorer or NUnit console.
6. View test reports in the Reports/ folder.

## Tech Stack

- Selenium WebDriver
- C# (.Net)
- NUnit 3
- JSON
- Page Object Model (POM)
- HTML Reporting & Screenshots

## Author

- John Levi P. Barcenas - [@Jhnlevi](https://github.com/Jhnlevi)