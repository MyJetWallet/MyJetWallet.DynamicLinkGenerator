using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyJetWallet.DynamicLinkGenerator.NoSql;
using MyNoSqlServer.DataWriter;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Divider = Math.Pow(10, 18);


            Console.WriteLine(decimal.ToDouble(decimal.Round(new decimal(2000000000000000000 / Divider), 18)));
            Console.WriteLine(decimal.ToInt64(decimal.Round(new decimal(2 * Divider), 0)));
            
            // Console.Write("Press enter to start");
            // Console.ReadLine();
            //
            // await GenerateAsstToBitgoMap();
            //
            //
            // MyNoSqlTcpClient myNoSqlClient =
            //     new MyNoSqlTcpClient(() => "192.168.10.80:5125", "test-bitgo-settings-app");
            //
            // var mapper = new AssetMapper(
            //     new MyNoSqlReadRepository<BitgoAssetMapEntity>(myNoSqlClient, BitgoAssetMapEntity.TableName),
            //     new MyNoSqlReadRepository<BitgoCoinEntity>(myNoSqlClient, BitgoCoinEntity.TableName));
            //
            // myNoSqlClient.Start();
            //
            // await Task.Delay(5000);
            //
            // var (coin, wallet) = mapper.AssetToBitgoCoinAndWallet("jetwallet", "BTC");
            // Console.WriteLine($"BTC (coin|wallet): {coin}|{wallet}");
            //
            // Console.WriteLine("End");
            // Console.ReadLine();
        }

    }
}