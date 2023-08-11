using System;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebScrap.Model;
using System.Collections.Generic;
using EasyAutomationFramework;

namespace WebScrap.Driver
{
    public class WebScrapper
    {
        public DataTable GetData(string link)
        {
            var items = new List<Item>();

            var options = new ChromeOptions();
            options.AddArguments("--headless"); // Executa o ChromeDriver no modo headless

            using (var driver = new ChromeDriver(options))
            {
                
                driver.Navigate().GoToUrl(link);
                //*[@id="splide01-list"]
                var consultaXPath = driver.FindElement(By.XPath("//*[@id=\"internal-content\"]/div[2]/div/ul")); // Acessa o container
                var consultaClass = consultaXPath.FindElements(By.ClassName("item-game")); // Acessa a classe

                foreach (var viewTeste in consultaClass)
                {
                    var item = new Item();
                    item.Title = viewTeste.FindElement(By.ClassName("item-game-name")).Text; // Nome do game
                    item.Date = viewTeste.FindElement(By.ClassName("item-game-release")).Text; // Data de lançamento
                    item.Score = viewTeste.FindElement(By.ClassName("item-game-score")).Text; // Score da crítica
                    items.Add(item);
                }
            }

            return Base.ConvertTo(items); // Converte em uma lista
        }
    }
}