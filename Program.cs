using EasyAutomationFramework;
using EasyAutomationFramework.Model;
using WebScrap.Driver;


var web = new GameList1();
var web1 = new GameList2();
var site1 = web.GetData("https://notadogame.com/list/featured-games"); 
var site2 = web1.GetData("https://www.metacritic.com/browse/games/score/metascore/all/pc/filtered?view=detailed");

var paramss = new ParamsDataTable("Jogos em alta", "C:\\Users\\Victor\\Desktop\\GamesList", new List<DataTables>() //(Nome do arquivo, caminho para o save)
{
    new DataTables("jogos", site1),
   
});
var paramss2 = new ParamsDataTable("Jogos PC em Alta", "C:\\Users\\Victor\\Desktop\\GamesList", new List<DataTables>() //(Nome do arquivo, caminho para o save)
{
    new DataTables("jogos", site2),
    
});


Base.GenerateExcel (paramss); // Cria um doc xlsx
Base.GenerateExcel (paramss2);
