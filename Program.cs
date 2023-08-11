using EasyAutomationFramework;
using EasyAutomationFramework.Model;
using WebScrap.Driver;


var web = new WebScrapper();
var jogos = web.GetData("https://notadogame.com/list/featured-games"); 

var paramss = new ParamsDataTable("Jogos em alta", "C:\\Users\\Victor\\Desktop\\GamesList", new List<DataTables>() //(Nome do arquivo, caminho para o save)
{
    new DataTables("jogos", jogos),
});


Base.GenerateExcel (paramss); // Cria um doc xlsx
