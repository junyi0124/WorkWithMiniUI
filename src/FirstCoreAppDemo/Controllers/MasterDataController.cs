using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using FirstCoreAppDemo.Data;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FirstCoreAppDemo.Controllers
{
    public class MasterDataController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IHostingEnvironment _env;
        private readonly ILogger _log;

        public MasterDataController(IHostingEnvironment env,
            ApplicationDbContext ctx,
            ILoggerFactory loggerFactory)
        {
            _env = env;
            _ctx = ctx;
            _log = loggerFactory.CreateLogger<MasterDataController>();
        }


        public async Task<IActionResult> Index()
        {
            await ClearData();
            ViewBag.ItemCount = await ReadCsvFile();
            return View();
        }

        private async Task ClearData()
        {
            var existData = await _ctx.Materials.CountAsync();
            if(existData > 0)
            {
                await _ctx.Database.ExecuteSqlCommandAsync("delete from materials;");
            }
        }

        private async Task<int> ReadCsvFile()
        {
            var masterDataFilePath = _env.ContentRootPath + @"\wwwroot\content\物料主数据维护.csv";

            using (var streamReader = new StreamReader(System.IO.File.OpenRead(masterDataFilePath)))
            {
                string line;
                streamReader.ReadLine(); //跳过第一行

                int lineCount = 0;
                while ((line = streamReader.ReadLine()) != null) {
                    _log.LogInformation(line);
                    lineCount++;

                    string[] importData = line.Split(',');
                    if (importData.Length != 7)
                    {
                        _log.LogInformation($"{lineCount}|-8 数据不足7位，请检查");
                    }
                    else
                    {
                        _ctx.Materials.Add(new Models.MaterialEntity
                        {
                            Code = importData[0],
                            FullName = importData[1],
                            Name = importData[2],
                            ParentCode = importData[3],
                            _level = int.Parse(importData[4]),
                            IsLeaf = bool.Parse(importData[5]),
                            SortNumber = int.Parse(importData[6])
                        });
                    }
                }
                return await _ctx.SaveChangesAsync();
            }
        }
    }
}