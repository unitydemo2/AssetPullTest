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
		driver.findElement(By.xpath("//input[@placeholder='User Name']")).sendKeys("QASystemAdmin");
		driver.findElement(By.xpath("//input[@placeholder='Password']")).sendKeys("QASystemAdmin");
		Thread.sleep(1000);
		driver.findElement(By.xpath("//button[@type='submit']")).click();
		Thread.sleep(1000);
		driver.findElement(By.xpath("//span[ contains(text(),'Create Project')]")).click();
		driver.findElement(By.xpath("//*[@placeholder='Project Title']"));
		driver.findElement(By.xpath("//span[contains(text(),'Type of Content')]"));
		driver.findElement(By.xpath("//*[@placeholder='Source Control Provider']"));


	}

}
