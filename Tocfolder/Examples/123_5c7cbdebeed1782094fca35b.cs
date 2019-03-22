package mypractice;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

public class Unity 
{

	public static void main(String[] args) throws InterruptedException
	{
System.setProperty("webdriver.chrome.driver", "D:\\Tejaswi\\Rythmos\\chromedriver.exe");
		
		WebDriver driver=new ChromeDriver();
		driver.get("https://docworksfrontendqa.azurewebsites.net/login?postLoginUrl=%2Fdashboard");
		driver.manage().window().maximize();
		Thread.sleep(1000);
		System.out.println("Hello World");

	}

}
