using System;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using WebScrap.Model;
using EasyAutomationFramework;

namespace WebScrap.Driver
{
    public class GameList2
    {
        public DataTable GetData(string link)
        {
            var items = new List<Item>();

            var options = new ChromeOptions();
            options.AddArguments("--headless"); // Executa o ChromeDriver no modo headless

            using (var driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(link);

                // Modifique os caminhos XPath de acordo com suas necessidades
                string[] xpaths = {
                    "//*[@id=\"main_content\"]/div[1]/div[2]/div/div[1]/div", // Substitua pelo seu XPath 1
                    "//*[@id=\"main_content\"]/div[1]/div[2]/div/div[1]/div/div[2]",
                    "//*[@id=\"main_content\"]/div[1]/div[2]/div/div[1]/div/div[4]",
                    "//*[@id=\"main_content\"]/div[1]/div[2]/div/div[1]/div/div[6]",
                    "//*[@id=\"main_content\"]/div[1]/div[2]/div/div[1]/div/div[8]"
                };

                foreach (string xpath in xpaths)
                {
                    try
                    {
                        IWebElement consultaXPath = driver.FindElement(By.XPath(xpath));
                        var consultaClass = consultaXPath.FindElements(By.ClassName("clamp-summary-wrap"));

                        foreach (var obj in consultaClass)
                        {
                            var item = new Item();

                            var gameElement = obj.FindElement(By.CssSelector("a.title h3"));
                            item.Title = gameElement.Text;

                            var detailsElement = obj.FindElement(By.ClassName("clamp-details"));
                            item.Date = detailsElement.Text; // Data de lançamento

                            var scoreElement = obj.FindElement(By.ClassName("metascore_anchor"));
                            item.Score = scoreElement.Text; // Score da crítica

                            items.Add(item);
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        Console.WriteLine("Elemento não encontrado para o XPath: " + xpath);
                    }
                }


            }

            return Base.ConvertTo(items); // Converte em uma lista
        }
    }
}