# 🚀 Data-Driven Selenium Framework

A simple and clean automation framework for web testing using Selenium WebDriver with C#.

## ✨ What it does

This framework automatically tests web login functionality using data from CSV files. It runs the same tests with different data sets across multiple browsers.

## 🛠️ Tech Stack

- **C#** - Programming language
- **Selenium WebDriver** - Browser automation
- **MSTest** - Testing framework
- **CSV** - Test data storage

## 🌐 Supported Browsers

- Chrome
- Edge  


```

## 🏃‍♂️ Quick Start

1. **Clone the repo**
   ```bash
   git clone https://github.com/AarishIrfan/DataDrivenSeleniumFramework.git
   ```

2. **Open in Visual Studio**

3. **Run Tests**
   - Build solution
   - Open Test Explorer
   - Run all tests

## 📊 Test Data Format

Create `Data.csv` with:
```csv
url,username,password
https://site1.com,user1,pass1
https://site2.com,user2,pass2
```

## 🧪 Test Cases

**TestCase_001** - Chrome with Login helper class  
**TestCase_002** - Chrome with direct element interaction  
**TestCase_003** - Edge browser testing  

Each test runs for every row in your CSV file!

## 🎯 Key Features

- **Data-driven** - One test, multiple data sets
- **Multi-browser** - Test across different browsers  
- **Smart waits** - No more flaky tests
- **Clean code** - Easy to understand and modify
- **CSV powered** - Simple data management

## 🔧 How it works

```csharp
// 1. Read data from CSV
string url = TestContext.DataRow["url"].ToString();
string username = TestContext.DataRow["username"].ToString();
string password = TestContext.DataRow["password"].ToString();

// 2. Open browser and navigate
IWebDriver driver = new ChromeDriver();
driver.Navigate().GoToUrl(url);

// 3. Fill login form
driver.FindElement(By.Id("username")).SendKeys(username);
driver.FindElement(By.Id("password")).SendKeys(password);

// 4. Smart click with JavaScript
((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", loginButton);
```

## 💡 Why this framework?

- **Simple** - Easy to understand and use
- **Reliable** - Uses explicit waits and JavaScript clicks
- **Flexible** - Add more test data without changing code
- **Maintainable** - Clean structure with page objects




