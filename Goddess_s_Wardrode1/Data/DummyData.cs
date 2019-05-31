using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goddess_s_Wardrode1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Goddess_s_Wardrode1.Data
{
    public class DummyData
    {


        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

               /*
                if (context.FashionWomens.Any() && context.ChineseCheongsams.Any())
                {
                    return;   // DB has already been seeded
                }
                */
                

                var fashionwomens = DummyData.GetFashionWomens().ToArray();
                context.FashionWomens.AddRange(fashionwomens);
                context.SaveChanges();

                var chinesecheongsams = DummyData.GetChineseCheongsams(context).ToArray();
                context.ChineseCheongsams.AddRange(chinesecheongsams);
                context.SaveChanges();
            }
        }


        public static List<FashionWomen> GetFashionWomens()
        {
            List<FashionWomen> fashionwomens = new List<FashionWomen>() {
            new FashionWomen() {
                //ID=001,
                Name="Dress 2019 new hollow crochet lace lace vintage temperament pink dress",
                Price="￥199",
                Picture="~/picture/a.jpg"

            },
            new FashionWomen() {
                //ID=002,
                Name="Summer new white t-shirt cotton and linen denim vest skirt top with skirt two-piece small fresh",
                Price="￥219",
                Picture="~/picture/b.jpg"
            },

            new FashionWomen() {
                //ID=003,
                Name="New small floral dress summer small fresh skirt literary shirt skirt long skirt",
                 Price="￥259",
                Picture="~/picture/c.jpg"
            },
            /*
            new FashionWomen() {

                Name="",

            },
            */
        };

            return fashionwomens;
        }

        public static List<ChineseCheongsam> GetChineseCheongsams(ApplicationDbContext context)
        {
            List<ChineseCheongsam> chinesecheongsams = new List<ChineseCheongsam>() {
            new ChineseCheongsam() {

                Name="Republic of China style art retro daily hemp print improved version with rotator sleeves long cheongsam dress 2019 new",
                 Price="￥359",
                Picture="~/picture/1.jpg"
               //context.Provinces.Find("1").ProvinceId
             
            },
            new ChineseCheongsam() {

                Name="Cheongsam women's 2019 summer new Chinese style daily improvement cotton and linen dark lines long retro Republic of China old Shanghai",
                Price="￥379",
                Picture="~/picture/2.jpg"
               //context.Provinces.Find("1").ProvinceId
            },
           new ChineseCheongsam() {

                 Name="Catwalk performance cheongsam female summer 2019 new Chinese style daily improved chiffon cover sleeve long dress",
                 Price="￥299",
                Picture="~/picture/3.jpg"
               //context.Provinces.Find("1").ProvinceId
            },
             new ChineseCheongsam() {

                 Name="Dora Banana soft silk cheongsam female elegant Chinese style retro daily improvement dress 2019 new",
                 Price="￥699",
                Picture="~/picture/4.jpg"
                //context.Provinces.Find("2").ProvinceId
            }
          /*  new ChineseCheongsam() {

            
               //context.Provinces.Find("2").ProvinceId
            },
               new ChineseCheongsam() {

              
                //context.Provinces.Find("2").ProvinceId
            },
               new ChineseCheongsam() {

              
               //context.Provinces.Find("3").ProvinceId
            },
               new ChineseCheongsam() {

                
               //context.Provinces.Find("3").ProvinceId
            },
               new ChineseCheongsam() {

                 
                //context.Provinces.Find("3").ProvinceId
            },
                 new ChineseCheongsam() {

                
               
                //context.Provinces.Find("4").ProvinceId
            },
                 new ChineseCheongsam() {

               
               //context.Provinces.Find("4").ProvinceId
            },
                new ChineseCheongsam() {

                
                //context.Provinces.Find("4").ProvinceId
            },*/

        };

            return chinesecheongsams;
        }
    }
}
