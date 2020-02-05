using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marvel.Api.Domain.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Marvel.Data
{
    public class DataGenerator
    {
        /// <summary>
        /// Inicializar o contexto do banco de dados (in memory) do json retirado da api da marvel.
        /// </summary>
        /// <param name="host"></param>
        public static void InitializeCharacters(IWebHost host)
        {
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    DataGenerator.InitializeCharacters(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<DataGenerator>>();
                    logger.LogError(ex, "An error occurred.");
                }
            }
        }

        private static void InitializeCharacters(IServiceProvider serviceProvider)
        {
            using (var context = new MarvelContext(
                serviceProvider.GetRequiredService<DbContextOptions<MarvelContext>>()))
            {
                if (context.Characters.Any())
                {
                    return; 
                }

                context.Characters.AddRange(Json2Data());

                context.SaveChanges();
            }
        }
        
        /// <summary>
        /// Array de personagens em formato de (string JSON)
        /// </summary>
        /// <returns></returns>
        private static Character[] Json2Data()
        {
            var jsonString =
          @"
        [
      {
        ""id"": 1009165,
        ""name"": ""Avengers"",
        ""description"": ""Earth-s Mightiest Heroes joined forces to take on threats that were too big for any one hero to tackle. With a roster that has included Captain America, Iron Man, Ant-Man, Hulk, Thor, Wasp and dozens more over the years, the Avengers have come to be regarded as Earth-s No. 1 team."",
        ""modified"": ""2019-02-06T18:03:00-0500"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/9/20/5102c774ebae7"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009165"",
        ""comics"": {
          ""available"": 1895,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009165/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/77059"",
              ""name"": ""Absolute Carnage: Avengers (2019) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/81255"",
              ""name"": ""Acts of Vengeance: Avengers (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/42539"",
              ""name"": ""Age of Apocalypse (2011) #2 (Avengers Art Appreciation Variant)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30090"",
              ""name"": ""Age of Heroes (2010) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/33566"",
              ""name"": ""Age of Heroes (2010) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30092"",
              ""name"": ""Age of Heroes (2010) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30093"",
              ""name"": ""Age of Heroes (2010) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37405"",
              ""name"": ""Age of Ultron (2013) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37406"",
              ""name"": ""Age of Ultron (2013) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37407"",
              ""name"": ""Age of Ultron (2013) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/45904"",
              ""name"": ""Age of Ultron (2013) #6""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/45905"",
              ""name"": ""Age of Ultron (2013) #7""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/45906"",
              ""name"": ""Age of Ultron (2013) #8""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/45907"",
              ""name"": ""Age of Ultron (2013) #9""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/45908"",
              ""name"": ""Age of Ultron (2013) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38524"",
              ""name"": ""Age of X: Universe (2011) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38523"",
              ""name"": ""Age of X: Universe (2011) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37278"",
              ""name"": ""Alias (2001) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37255"",
              ""name"": ""Alias Omnibus (Hardcover)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43473"",
              ""name"": ""All-New X-Men (2012) #8""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 558,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009165/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/27631"",
              ""name"": ""Absolute Carnage: Avengers (2019)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/29061"",
              ""name"": ""Acts of Vengeance: Avengers (2020)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/15331"",
              ""name"": ""Age of Apocalypse (2011 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9790"",
              ""name"": ""Age of Heroes (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/17318"",
              ""name"": ""Age of Ultron (2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13896"",
              ""name"": ""Age of X: Universe (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/672"",
              ""name"": ""Alias (2001 - 2003)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13383"",
              ""name"": ""Alias Omnibus (2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16449"",
              ""name"": ""All-New X-Men (2012 - 2015)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/20443"",
              ""name"": ""All-New, All-Different Avengers (2015 - 2016)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/22374"",
              ""name"": ""All-New, All-Different Avengers (2017)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/22190"",
              ""name"": ""All-New, All-Different Avengers Annual (2016)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/719"",
              ""name"": ""Alpha Flight (2004 - 2005)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2116"",
              ""name"": ""Alpha Flight (1983 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/454"",
              ""name"": ""Amazing Spider-Man (1999 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2984"",
              ""name"": ""Amazing Spider-Man Annual (1964 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24403"",
              ""name"": ""Amazing Spider-Man Epic Collection: Spider-Man No More (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/5376"",
              ""name"": ""Amazing Spider-Man Family (2008 - 2009)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1489"",
              ""name"": ""AMAZING SPIDER-MAN VOL. 10: NEW AVENGERS TPB (2005)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16312"",
              ""name"": ""Amazing Spider-Man: Ends of the Earth (2012)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 2698,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009165/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/490"",
              ""name"": ""Interior #490"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/542"",
              ""name"": ""Interior #542"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/572"",
              ""name"": ""Interior #572"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/574"",
              ""name"": ""Interior #574"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/575"",
              ""name"": ""Interior #575"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/577"",
              ""name"": ""Interior #577"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/579"",
              ""name"": ""Interior #579"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/580"",
              ""name"": ""Interior #580"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/749"",
              ""name"": ""1 of 4 - Season of the Witch"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/892"",
              ""name"": ""THOR (1998) #81"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1024"",
              ""name"": ""Avengers (1998) #80"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1025"",
              ""name"": ""Interior #1025"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1026"",
              ""name"": ""Avengers (1998) #81"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1027"",
              ""name"": ""Interior #1027"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1029"",
              ""name"": ""Interior #1029"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1031"",
              ""name"": ""Interior #1031"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1039"",
              ""name"": ""Interior #1039"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1041"",
              ""name"": ""Avengers (1998) #502"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1043"",
              ""name"": ""Interior #1043"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1054"",
              ""name"": ""Avengers (1998) #72"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 34,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009165/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/116"",
              ""name"": ""Acts of Vengeance!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/314"",
              ""name"": ""Age of Ultron""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/303"",
              ""name"": ""Age of X""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/233"",
              ""name"": ""Atlantis Attacks""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/234"",
              ""name"": ""Avengers Disassembled""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/310"",
              ""name"": ""Avengers VS X-Men""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/296"",
              ""name"": ""Chaos War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/239"",
              ""name"": ""Crossing""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/318"",
              ""name"": ""Dark Reign""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/246"",
              ""name"": ""Evolutionary War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/251"",
              ""name"": ""House of M""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/252"",
              ""name"": ""Inferno""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/315"",
              ""name"": ""Infinity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/29"",
              ""name"": ""Infinity War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/317"",
              ""name"": ""Inhumanity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/255"",
              ""name"": ""Initiative""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/37"",
              ""name"": ""Maximum Security""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/333"",
              ""name"": ""Monsters Unleashed""
            }
          ],
          ""returned"": 20
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009165/avengers?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Avengers?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009165/avengers?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009187,
        ""name"": ""Black Panther"",
        ""description"": """",
        ""modified"": ""2018-06-19T16:39:46-0400"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/6/60/5261a80a67e7d"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009187"",
        ""comics"": {
          ""available"": 641,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009187/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43498"",
              ""name"": ""A+X (2012) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30885"",
              ""name"": ""AGE OF HEROES TPB (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/16889"",
              ""name"": ""Amazing Spider-Man Annual (1964) #15""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/16900"",
              ""name"": ""Amazing Spider-Man Annual (1964) #25""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43221"",
              ""name"": ""Astonishing X-Men (2004) #51 (Create Your Own Wedding Variant)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67002"",
              ""name"": ""Avengers (2018) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17490"",
              ""name"": ""Avengers (1998) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17501"",
              ""name"": ""Avengers (1998) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67311"",
              ""name"": ""Avengers (2018) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17512"",
              ""name"": ""Avengers (1998) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17523"",
              ""name"": ""Avengers (1998) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67763"",
              ""name"": ""Avengers (2018) #6""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67769"",
              ""name"": ""Avengers (2018) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17500"",
              ""name"": ""Avengers (1998) #19""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17502"",
              ""name"": ""Avengers (1998) #20""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17503"",
              ""name"": ""Avengers (1998) #21""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17504"",
              ""name"": ""Avengers (1998) #22""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17505"",
              ""name"": ""Avengers (1998) #23""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17532"",
              ""name"": ""Avengers (1998) #48""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7301"",
              ""name"": ""Avengers (1963) #51""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 212,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009187/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16450"",
              ""name"": ""A+X (2012 - 2014)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/10235"",
              ""name"": ""AGE OF HEROES TPB (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/454"",
              ""name"": ""Amazing Spider-Man (1999 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2984"",
              ""name"": ""Amazing Spider-Man Annual (1964 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/744"",
              ""name"": ""Astonishing X-Men (2004 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/354"",
              ""name"": ""Avengers (1998 - 2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1991"",
              ""name"": ""Avengers (1963 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1988"",
              ""name"": ""Avengers Annual (1967 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1340"",
              ""name"": ""Avengers Assemble (2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1737"",
              ""name"": ""Avengers Assemble Vol. 3 (2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1816"",
              ""name"": ""Avengers Assemble Vol. 4 (2007)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/26625"",
              ""name"": ""Avengers Assemble: Living Legends (2019)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2384"",
              ""name"": ""Avengers Classic (2007 - 2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3971"",
              ""name"": ""Avengers Fairy Tales (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2111"",
              ""name"": ""Avengers Forever (1998 - 2001)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9863"",
              ""name"": ""Avengers Origins: Vision (2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/158"",
              ""name"": ""Avengers Vol. 1: World Trust (2003)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/227"",
              ""name"": ""Avengers Vol. 2: Red Zone (2003)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/271"",
              ""name"": ""Avengers Vol. II: Red Zone (2003)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 862,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009187/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/650"",
              ""name"": ""2 of 2- Black Panther crossover"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1820"",
              ""name"": ""Cover #1820"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3812"",
              ""name"": ""1 of 6- Who is the Black Panther"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3813"",
              ""name"": ""1 of 6- Who is the Black Panther"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3814"",
              ""name"": ""2 of 6- Who is the Black Panther"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3815"",
              ""name"": ""2 of 6- Who is the Black Panther"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3816"",
              ""name"": ""3 of 6- Who is the Black Panther"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3817"",
              ""name"": ""3 of 6- Who is the Black Panther"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3818"",
              ""name"": ""4 of 6- Who is the Black Panther"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3819"",
              ""name"": ""4 of 6- Who is the Black Panther"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3820"",
              ""name"": ""5 of 6- Who is the Black Panther"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3821"",
              ""name"": ""5 of 6- Who is the Black Panther"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3822"",
              ""name"": ""6 of 6- Who is the Black Panther"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3823"",
              ""name"": ""6 of 6- Who is the Black Panther"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3825"",
              ""name"": ""1 of 1- House of M"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3826"",
              ""name"": ""1 of 2 - (X-Men crossover)"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3827"",
              ""name"": ""1 of 2 - (X-Men crossover)"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3828"",
              ""name"": ""2 of 2 - X-Men crossover"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3829"",
              ""name"": ""2 of 2 - X-Men crossover"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3831"",
              ""name"": ""1 of 4 - Bride Prelude"",
              ""type"": ""interiorStory""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 17,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009187/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/318"",
              ""name"": ""Dark Reign""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/248"",
              ""name"": ""Fall of the Mutants""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/251"",
              ""name"": ""House of M""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/315"",
              ""name"": ""Infinity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/317"",
              ""name"": ""Inhumanity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/255"",
              ""name"": ""Initiative""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/311"",
              ""name"": ""Marvel NOW!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/37"",
              ""name"": ""Maximum Security""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/154"",
              ""name"": ""Onslaught""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/319"",
              ""name"": ""Original Sin""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/266"",
              ""name"": ""Other - Evolve or Die""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/336"",
              ""name"": ""Secret Empire""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/269"",
              ""name"": ""Secret Invasion""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/305"",
              ""name"": ""Spider-Island""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/277"",
              ""name"": ""World War Hulk""
            }
          ],
          ""returned"": 17
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009187/black_panther?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Black_Panther_(T%27Challa)?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009187/black_panther?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009191,
        ""name"": ""Blade"",
        ""description"": """",
        ""modified"": ""2013-09-20T15:50:53-0400"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/8/a0/523ca6f2b11e4"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009191"",
        ""comics"": {
          ""available"": 90,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009191/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/71049"",
              ""name"": ""Avengers (2018) #16""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/3356"",
              ""name"": ""Black Panther (2005) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/65441"",
              ""name"": ""Black Panther by Reginald Hudlin: The Complete Collection Vol. 1 (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/4140"",
              ""name"": ""Black Panther: Bad Mutha (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/74892"",
              ""name"": ""Blade (1998) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/5133"",
              ""name"": ""Blade (2006) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/5288"",
              ""name"": ""Blade (2006) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/74893"",
              ""name"": ""Blade (1998) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/5596"",
              ""name"": ""Blade (2006) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/74894"",
              ""name"": ""Blade (1998) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/5713"",
              ""name"": ""Blade (2006) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/5849"",
              ""name"": ""Blade (2006) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/5917"",
              ""name"": ""Blade (2006) #5 (Bloody Variant)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/6002"",
              ""name"": ""Blade (2006) #6""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/6129"",
              ""name"": ""Blade (2006) #7""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/6267"",
              ""name"": ""Blade (2006) #8""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/13475"",
              ""name"": ""Blade (2006) #9""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/15854"",
              ""name"": ""Blade (2006) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/15964"",
              ""name"": ""Blade (2006) #11""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/16149"",
              ""name"": ""Blade (2006) #12""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 43,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009191/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/784"",
              ""name"": ""Black Panther (2005 - 2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/23806"",
              ""name"": ""Black Panther by Reginald Hudlin: The Complete Collection Vol. 1 (2017)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1479"",
              ""name"": ""Black Panther: Bad Mutha (2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1123"",
              ""name"": ""Blade (2006 - 2007)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/26963"",
              ""name"": ""Blade (1998)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/22633"",
              ""name"": ""Blade the Vampire Hunter (1994 - 1995)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1249"",
              ""name"": ""Blade: Black & White (2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/25798"",
              ""name"": ""Blade: Blood and Chaos (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/21235"",
              ""name"": ""Blade: Crescent City Blues (1998)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/26710"",
              ""name"": ""BLADE: SINS OF THE FATHER 1 (1998)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2931"",
              ""name"": ""BLADE: SINS OF THE FATHER TPB (2007)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2236"",
              ""name"": ""BLADE: UNDEAD AGAIN TPB (2007)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/26394"",
              ""name"": ""Blade: Vampire Hunter (1999 - 2000)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/4884"",
              ""name"": ""Captain Britain and MI: 13 (2008 - 2009)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/21932"",
              ""name"": ""Darkhold: Pages from The Book of Sins (1992)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3741"",
              ""name"": ""Doctor Strange, Sorcerer Supreme (1988 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24016"",
              ""name"": ""Doctor Strange: Damnation (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/25782"",
              ""name"": ""Doctor Strange: Damnation (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/23603"",
              ""name"": ""Falcon (2017 - 2018)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 103,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009191/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3834"",
              ""name"": ""3 of 4 - Bride Prelude"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4117"",
              ""name"": ""2 of 6 - Master of the Ring"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6172"",
              ""name"": ""Cover #6172"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6173"",
              ""name"": ""Interior #6173"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6174"",
              ""name"": ""1 of 1 - Dr. Doom and Latveria"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6175"",
              ""name"": ""1 of 1 - Dr. Doom and Latveria"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6177"",
              ""name"": ""Interior #6177"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6178"",
              ""name"": ""Cover #6178"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6179"",
              ""name"": ""Interior #6179"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6180"",
              ""name"": ""5 of 6 - Fathers and Sons"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6181"",
              ""name"": ""5 of 6 - Fathers and Sons"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6182"",
              ""name"": ""5 of 6 - Fathers and Sons"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6183"",
              ""name"": ""5 of 6 - Fathers and Sons"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/7876"",
              ""name"": ""6 of 6 - Fathers and Sons"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/7877"",
              ""name"": ""6 of 6 - Fathers and Sons"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/7879"",
              ""name"": ""1 of 6 - Death of Blade"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/8330"",
              ""name"": ""1 of 6 - Death of Blade"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/8332"",
              ""name"": ""Tyrana 2 of 6"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/8678"",
              ""name"": ""Tyrana 3 of 6"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/20022"",
              ""name"": ""Cover #20022"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 3,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009191/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/336"",
              ""name"": ""Secret Empire""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/219"",
              ""name"": ""Siege of Darkness""
            }
          ],
          ""returned"": 3
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/characters/295/blade?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Blade_(Eric_Brooks)?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009191/blade?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009220,
        ""name"": ""Captain America"",
        ""description"": ""Vowing to serve his country any way he could, young Steve Rogers took the super soldier serum to become America-s one-man army. Fighting for the red, white and blue for over 60 years, Captain America is the living, breathing symbol of freedom and liberty."",
        ""modified"": ""2016-09-06T11:37:19-0400"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/3/50/537ba56d31087"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009220"",
        ""comics"": {
          ""available"": 2348,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009220/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43488"",
              ""name"": ""A+X (2012) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43501"",
              ""name"": ""A+X (2012) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43508"",
              ""name"": ""A+X (2012) #9""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17743"",
              ""name"": ""A-Next (1998) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17744"",
              ""name"": ""A-Next (1998) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17745"",
              ""name"": ""A-Next (1998) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17746"",
              ""name"": ""A-Next (1998) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17747"",
              ""name"": ""A-Next (1998) #6""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17748"",
              ""name"": ""A-Next (1998) #7""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17749"",
              ""name"": ""A-Next (1998) #8""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17750"",
              ""name"": ""A-Next (1998) #9""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17740"",
              ""name"": ""A-Next (1998) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17741"",
              ""name"": ""A-Next (1998) #11""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17742"",
              ""name"": ""A-Next (1998) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/66978"",
              ""name"": ""Adventures of Captain America (1991) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/66979"",
              ""name"": ""Adventures of Captain America (1991) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/66980"",
              ""name"": ""Adventures of Captain America (1991) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/66981"",
              ""name"": ""Adventures of Captain America (1991) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/42539"",
              ""name"": ""Age of Apocalypse (2011) #2 (Avengers Art Appreciation Variant)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30090"",
              ""name"": ""Age of Heroes (2010) #1""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 641,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009220/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16450"",
              ""name"": ""A+X (2012 - 2014)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3620"",
              ""name"": ""A-Next (1998 - 1999)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24227"",
              ""name"": ""Adventures of Captain America (1991 - 1992)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/15331"",
              ""name"": ""Age of Apocalypse (2011 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9790"",
              ""name"": ""Age of Heroes (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/10235"",
              ""name"": ""AGE OF HEROES TPB (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13896"",
              ""name"": ""Age of X: Universe (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/7534"",
              ""name"": ""All Winners Comics 70th Anniversary Special (2009)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/20682"",
              ""name"": ""All-New Wolverine (2015 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2114"",
              ""name"": ""All-Winners Comics (1941 - 1947)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9865"",
              ""name"": ""All-Winners Squad: Band of Heroes (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2116"",
              ""name"": ""Alpha Flight (1983 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/454"",
              ""name"": ""Amazing Spider-Man (1999 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2984"",
              ""name"": ""Amazing Spider-Man Annual (1964 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/15540"",
              ""name"": ""Amazing Spider-Man Annual (2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9802"",
              ""name"": ""Amazing Spider-Man Annual (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1489"",
              ""name"": ""AMAZING SPIDER-MAN VOL. 10: NEW AVENGERS TPB (2005)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/14818"",
              ""name"": ""Annihilators: Earthfall (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24323"",
              ""name"": ""Ant-Man and the Wasp Adventures (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/14696"",
              ""name"": ""Art of Marvel Movies: The Art of Captain America - The First Avenger (2011 - Present)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 3483,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009220/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/670"",
              ""name"": ""X-MEN (2004) #186"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/892"",
              ""name"": ""THOR (1998) #81"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/960"",
              ""name"": ""3 of ?"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1026"",
              ""name"": ""Avengers (1998) #81"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1041"",
              ""name"": ""Avengers (1998) #502"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1042"",
              ""name"": ""Avengers (1998) #503"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1054"",
              ""name"": ""Avengers (1998) #72"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1163"",
              ""name"": ""Amazing Spider-Man (1999) #519"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1165"",
              ""name"": ""Amazing Spider-Man (1999) #520"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1167"",
              ""name"": ""Amazing Spider-Man (1999) #521"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1175"",
              ""name"": ""Amazing Spider-Man (1999) #523"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1193"",
              ""name"": ""Amazing Spider-Man (1999) #534"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1199"",
              ""name"": ""Amazing Spider-Man (1999) #537"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1203"",
              ""name"": ""Amazing Spider-Man (1999) #538"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1414"",
              ""name"": ""Cover #1414"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1500"",
              ""name"": ""Interior #1500"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1501"",
              ""name"": ""CAPTAIN AMERICA (2002) #21"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1503"",
              ""name"": ""CAPTAIN AMERICA (2002) #22"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1505"",
              ""name"": ""CAPTAIN AMERICA (2002) #23"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1606"",
              ""name"": ""WEAPON X (2002) #14"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 30,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009220/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/116"",
              ""name"": ""Acts of Vengeance!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/314"",
              ""name"": ""Age of Ultron""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/303"",
              ""name"": ""Age of X""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/231"",
              ""name"": ""Armor Wars""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/234"",
              ""name"": ""Avengers Disassembled""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/310"",
              ""name"": ""Avengers VS X-Men""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/320"",
              ""name"": ""Axis""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/296"",
              ""name"": ""Chaos War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/248"",
              ""name"": ""Fall of the Mutants""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/251"",
              ""name"": ""House of M""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/252"",
              ""name"": ""Inferno""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/315"",
              ""name"": ""Infinity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/29"",
              ""name"": ""Infinity War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/317"",
              ""name"": ""Inhumanity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/151"",
              ""name"": ""Maximum Carnage""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/37"",
              ""name"": ""Maximum Security""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/333"",
              ""name"": ""Monsters Unleashed""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/337"",
              ""name"": ""Monsters Unleashed""
            }
          ],
          ""returned"": 20
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009220/captain_america?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Captain_America_(Steve_Rogers)?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009220/captain_america?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1010338,
        ""name"": ""Captain Marvel (Carol Danvers)"",
        ""description"": """",
        ""modified"": ""2019-02-06T18:09:05-0500"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/6/80/5269608c1be7a"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1010338"",
        ""comics"": {
          ""available"": 497,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1010338/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/58636"",
              ""name"": ""Marvel New Year-s Eve Special Infinite Comic (2017) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43505"",
              ""name"": ""A+X (2012) #6""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56017"",
              ""name"": ""A-Force (2016) #6""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56018"",
              ""name"": ""A-Force (2016) #7""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56019"",
              ""name"": ""A-Force (2016) #8""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56020"",
              ""name"": ""A-Force (2016) #9""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56021"",
              ""name"": ""A-Force (2016) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/77217"",
              ""name"": ""Absolute Carnage: Captain Marvel (2019) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/24348"",
              ""name"": ""Adam: Legend of the Blue Marvel (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/22461"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/23733"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/24222"",
              ""name"": ""Agents of Atlas (2009) #5 (MCGUINNESS VARIANT)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37277"",
              ""name"": ""Alias (2001) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37280"",
              ""name"": ""Alias (2001) #6""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37255"",
              ""name"": ""Alias Omnibus (Hardcover)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/60276"",
              ""name"": ""All-New, All-Different Avengers Annual (2016) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12638"",
              ""name"": ""Alpha Flight (1983) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/4277"",
              ""name"": ""Amazing Spider-Man (1999) #533""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/32217"",
              ""name"": ""Amazing Spider-Man (1999) #653""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/35521"",
              ""name"": ""Amazing Spider-Man (1999) #654""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 175,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1010338/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16450"",
              ""name"": ""A+X (2012 - 2014)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/20606"",
              ""name"": ""A-Force (2016)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/27665"",
              ""name"": ""Absolute Carnage: Captain Marvel (2019)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/7524"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6079"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6807"",
              ""name"": ""Agents of Atlas (2009)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/672"",
              ""name"": ""Alias (2001 - 2003)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13383"",
              ""name"": ""Alias Omnibus (2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/22190"",
              ""name"": ""All-New, All-Different Avengers Annual (2016)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2116"",
              ""name"": ""Alpha Flight (1983 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/454"",
              ""name"": ""Amazing Spider-Man (1999 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/14818"",
              ""name"": ""Annihilators: Earthfall (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/354"",
              ""name"": ""Avengers (1998 - 2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9085"",
              ""name"": ""Avengers (2010 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9859"",
              ""name"": ""Avengers & the Infinity Gauntlet (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13320"",
              ""name"": ""Avengers Annual (2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1340"",
              ""name"": ""Avengers Assemble (2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/15373"",
              ""name"": ""Avengers Assemble (2012 - 2014)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1496"",
              ""name"": ""Avengers Assemble Vol. 2 (2005)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 596,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1010338/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1191"",
              ""name"": ""Amazing Spider-Man (1999) #533"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2359"",
              ""name"": ""1 of"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3411"",
              ""name"": ""1 of 4 - Nimrod"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3479"",
              ""name"": ""2 of 2 - Spider-Woman"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4125"",
              ""name"": ""3 of 3 - Titannus War"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5559"",
              ""name"": ""1 of 3  - Best of the Best"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5561"",
              ""name"": ""2 of 3  - Best of the Best"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5563"",
              ""name"": ""3 of 3  - Best of the Best"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5565"",
              ""name"": ""1 of 2 -"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5567"",
              ""name"": ""2 of 2 -"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5569"",
              ""name"": ""1 of 3 - Civil War"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5571"",
              ""name"": ""2 of 3 - Civil War"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5573"",
              ""name"": ""3 of 3 - Civil War"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5575"",
              ""name"": ""1 of 2 - Rogue"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5577"",
              ""name"": ""2 of 2 - Rogue"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5579"",
              ""name"": ""1 of 2 - Initiative"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5872"",
              ""name"": ""1 of 7 - 7XLS"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5903"",
              ""name"": ""7 of 7 - 7XLS"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5905"",
              ""name"": ""Cover #5905"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5907"",
              ""name"": ""Cover #5907"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 16,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1010338/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/310"",
              ""name"": ""Avengers VS X-Men""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/318"",
              ""name"": ""Dark Reign""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/240"",
              ""name"": ""Days of Future Present""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/248"",
              ""name"": ""Fall of the Mutants""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/315"",
              ""name"": ""Infinity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/255"",
              ""name"": ""Initiative""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/311"",
              ""name"": ""Marvel NOW!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/37"",
              ""name"": ""Maximum Security""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/337"",
              ""name"": ""Monsters Unleashed""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/333"",
              ""name"": ""Monsters Unleashed""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/336"",
              ""name"": ""Secret Empire""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/269"",
              ""name"": ""Secret Invasion""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/305"",
              ""name"": ""Spider-Island""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/277"",
              ""name"": ""World War Hulk""
            }
          ],
          ""returned"": 16
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1010338/captain_marvel_carol_danvers?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Ms._Marvel_(Carol_Danvers)?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1010338/captain_marvel_carol_danvers?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1010813,
        ""name"": ""Celestials"",
        ""description"": """",
        ""modified"": ""1969-12-31T19:00:00-0500"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/8/f0/4c0035efbf930"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1010813"",
        ""comics"": {
          ""available"": 16,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1010813/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67762"",
              ""name"": ""Avengers (2018) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8549"",
              ""name"": ""Earth X (1999) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/22420"",
              ""name"": ""Hulk: Heart of the Atom Premiere (Hardcover)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/19870"",
              ""name"": ""Iron Man Annual (1976) #6""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30511"",
              ""name"": ""S.H.I.E.L.D. (2010) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30512"",
              ""name"": ""S.H.I.E.L.D. (2010) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/11777"",
              ""name"": ""Thor (1966) #449""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/11778"",
              ""name"": ""Thor (1966) #450""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/36070"",
              ""name"": ""Thor: Black Galaxy Saga TPB (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/64220"",
              ""name"": ""True Believers: Kirby 100th - Eternals (2017) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/40159"",
              ""name"": ""Uncanny X-Men (2011) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/11905"",
              ""name"": ""Universe X (2000) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12136"",
              ""name"": ""What If? (1977) #23""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17482"",
              ""name"": ""What If? Classic Vol. 4 (2007)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/23500"",
              ""name"": ""X-51 (1999) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12359"",
              ""name"": ""X-Men Annual (1970) #13""
            }
          ],
          ""returned"": 16
        },
        ""series"": {
          ""available"": 14,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1010813/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/378"",
              ""name"": ""Earth X (1999)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6043"",
              ""name"": ""Hulk: Heart of the Atom Premiere (2008 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3723"",
              ""name"": ""Iron Man Annual (1976 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/8821"",
              ""name"": ""S.H.I.E.L.D. (2010 - 2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2083"",
              ""name"": ""Thor (1966 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/12847"",
              ""name"": ""Thor: Black Galaxy Saga TPB (2010 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/23406"",
              ""name"": ""True Believers: Kirby 100th - Eternals (2017)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/14914"",
              ""name"": ""Uncanny X-Men (2011 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2085"",
              ""name"": ""Universe X (2000 - 2001)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2095"",
              ""name"": ""What If? (1977 - 1984)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3314"",
              ""name"": ""What If? Classic Vol. 4 (2007)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6688"",
              ""name"": ""X-51 (1999 - 2000)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2100"",
              ""name"": ""X-Men Annual (1970 - 1994)""
            }
          ],
          ""returned"": 14
        },
        ""stories"": {
          ""available"": 18,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1010813/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/17237"",
              ""name"": ""Thor (1966) #449"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/17240"",
              ""name"": ""Thor (1966) #450"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/19858"",
              ""name"": ""The Saga of the Serpent Crown Part 3: Serpent In the Garden"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/20703"",
              ""name"": ""The First Celestial Host!"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/24907"",
              ""name"": ""Cover #24907"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/25637"",
              ""name"": ""Universe X (2000) #12"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/25638"",
              ""name"": ""Interior #25638"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/42599"",
              ""name"": ""Cover #42599"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/52136"",
              ""name"": ""Space Odyssey"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/69848"",
              ""name"": ""S.H.I.E.L.D (2010) #4"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/69849"",
              ""name"": ""S.H.I.E.L.D (2010) #4 "",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/69850"",
              ""name"": ""S.H.I.E.L.D (2010) #5"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/69851"",
              ""name"": ""S.H.I.E.L.D (2010) #5"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/76346"",
              ""name"": ""S.H.I.E.L.D (2010) #1"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/79826"",
              ""name"": ""Interior #79826"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/91116"",
              ""name"": ""Interior #91116"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/139417"",
              ""name"": ""cover from True Believers: Kirby 100th - Eternals (2017) #1"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/146908"",
              ""name"": ""cover from Avengers (2018) #5"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 18
        },
        ""events"": {
          ""available"": 2,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1010813/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/233"",
              ""name"": ""Atlantis Attacks""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/308"",
              ""name"": ""X-Men: Regenesis""
            }
          ],
          ""returned"": 2
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1010813/celestials?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Celestials?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1010813/celestials?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009282,
        ""name"": ""Doctor Strange"",
        ""description"": """",
        ""modified"": ""2016-09-28T12:03:08-0400"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/5/f0/5261a85a501fe"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009282"",
        ""comics"": {
          ""available"": 822,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009282/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43508"",
              ""name"": ""A+X (2012) #9""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/29317"",
              ""name"": ""ACTS OF VENGEANCE CROSSOVERS OMNIBUS (Hardcover)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/29318"",
              ""name"": ""ACTS OF VENGEANCE CROSSOVERS OMNIBUS (DM Only) (Hardcover)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/61524"",
              ""name"": ""All-New Guardians of the Galaxy (2017) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56435"",
              ""name"": ""All-New Wolverine (2015) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12668"",
              ""name"": ""Alpha Flight (1983) #127""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/6745"",
              ""name"": ""The Amazing Spider-Man (1963) #336""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/277"",
              ""name"": ""Amazing Spider-Man (1999) #500""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/361"",
              ""name"": ""Amazing Spider-Man (1999) #504""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30314"",
              ""name"": ""Amazing Spider-Man (1999) #639""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/34118"",
              ""name"": ""Amazing Spider-Man (1999) #640""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/35509"",
              ""name"": ""Amazing Spider-Man (1999) #673""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/16883"",
              ""name"": ""Amazing Spider-Man Annual (1964) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/16894"",
              ""name"": ""Amazing Spider-Man Annual (1964) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/16888"",
              ""name"": ""Amazing Spider-Man Annual (1964) #14""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/1262"",
              ""name"": ""Amazing Spider-Man Vol. 6 (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/2970"",
              ""name"": ""AMAZING SPIDER-MAN VOL. 7: BOOK OF EZEKIEL TPB (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/1333"",
              ""name"": ""Amazing Spider-Man Vol. 7: The Book of Ezekiel (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67002"",
              ""name"": ""Avengers (2018) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67311"",
              ""name"": ""Avengers (2018) #2""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 269,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009282/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16450"",
              ""name"": ""A+X (2012 - 2014)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9994"",
              ""name"": ""ACTS OF VENGEANCE CROSSOVERS OMNIBUS (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9995"",
              ""name"": ""ACTS OF VENGEANCE CROSSOVERS OMNIBUS (DM Only) (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/23058"",
              ""name"": ""All-New Guardians of the Galaxy (2017)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/20682"",
              ""name"": ""All-New Wolverine (2015 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2116"",
              ""name"": ""Alpha Flight (1983 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/454"",
              ""name"": ""Amazing Spider-Man (1999 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2984"",
              ""name"": ""Amazing Spider-Man Annual (1964 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/318"",
              ""name"": ""Amazing Spider-Man Vol. 6 (2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1292"",
              ""name"": ""AMAZING SPIDER-MAN VOL. 7: BOOK OF EZEKIEL TPB (2005)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1291"",
              ""name"": ""Amazing Spider-Man Vol. 7: The Book of Ezekiel (2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9085"",
              ""name"": ""Avengers (2010 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1991"",
              ""name"": ""Avengers (1963 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9086"",
              ""name"": ""Avengers Academy (2010 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13320"",
              ""name"": ""Avengers Annual (2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1988"",
              ""name"": ""Avengers Annual (1967 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/94"",
              ""name"": ""Avengers Legends Vol. II: George Perez Book I (1999)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/15305"",
              ""name"": ""Avengers Vs. X-Men (2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/4864"",
              ""name"": ""Avengers/Invaders (2008 - 2009)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 1045,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009282/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1018"",
              ""name"": ""Amazing Spider-Man (1999) #500"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1666"",
              ""name"": ""Interior #1666"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1838"",
              ""name"": ""Spectacular Spider-Man (2003) #21"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1839"",
              ""name"": ""1 of 1 - Card Game"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2359"",
              ""name"": ""1 of"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2361"",
              ""name"": ""2 of - Fear"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3099"",
              ""name"": ""1 of 5"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3463"",
              ""name"": ""3 of 3 - Sentry"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3469"",
              ""name"": ""4 of 4 - Sentry"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3500"",
              ""name"": ""New Avengers (2004) #26"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3846"",
              ""name"": ""5 of 5 - Bride of the Panther"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3848"",
              ""name"": ""Cover #3848"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3954"",
              ""name"": ""4 of 6 - 6XLS"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3956"",
              ""name"": ""5 of 6 - 6XLS"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4107"",
              ""name"": ""1 of 1 - Fantastic Four & Dr. Strange"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4123"",
              ""name"": ""5 of 6 - Master of the Ring"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4656"",
              ""name"": ""Friendly Neighborhood Spider-Man (2005) #2"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4657"",
              ""name"": ""2 of 6"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5564"",
              ""name"": ""1 of 2 -"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5688"",
              ""name"": ""1 of 5 - A Long Time Dead"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 22,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009282/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/116"",
              ""name"": ""Acts of Vengeance!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/310"",
              ""name"": ""Avengers VS X-Men""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/235"",
              ""name"": ""Blood and Thunder""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/296"",
              ""name"": ""Chaos War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/318"",
              ""name"": ""Dark Reign""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/315"",
              ""name"": ""Infinity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/29"",
              ""name"": ""Infinity War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/317"",
              ""name"": ""Inhumanity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/255"",
              ""name"": ""Initiative""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/311"",
              ""name"": ""Marvel NOW!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/37"",
              ""name"": ""Maximum Security""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/154"",
              ""name"": ""Onslaught""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/319"",
              ""name"": ""Original Sin""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/266"",
              ""name"": ""Other - Evolve or Die""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/336"",
              ""name"": ""Secret Empire""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/270"",
              ""name"": ""Secret Wars""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/271"",
              ""name"": ""Secret Wars II""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/309"",
              ""name"": ""Shattered Heroes""
            }
          ],
          ""returned"": 20
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009282/doctor_strange?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Doctor_Strange_(Stephen_Strange)?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009282/doctor_strange?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009318,
        ""name"": ""Ghost Rider (Johnny Blaze)"",
        ""description"": """",
        ""modified"": ""2013-10-24T14:49:42-0400"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/3/80/52696ba1353e7"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009318"",
        ""comics"": {
          ""available"": 288,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009318/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38524"",
              ""name"": ""Age of X: Universe (2011) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38461"",
              ""name"": ""Amazing Spider-Man/Ghost Rider - Motorstorm (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/71055"",
              ""name"": ""Avengers (2018) #22""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/71056"",
              ""name"": ""Avengers (2018) #23""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/71057"",
              ""name"": ""Avengers (2018) #24""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/71058"",
              ""name"": ""Avengers (2018) #25""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17509"",
              ""name"": ""Avengers (1998) #27""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7080"",
              ""name"": ""Avengers (1963) #214""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/4461"",
              ""name"": ""Avengers Assemble Vol. 3 (Hardcover)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43107"",
              ""name"": ""Captain America and Bucky (2011) #640""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/3380"",
              ""name"": ""Captain Universe: Universal Heroes (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8055"",
              ""name"": ""Champions (1975) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8064"",
              ""name"": ""Champions (1975) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8065"",
              ""name"": ""Champions (1975) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8066"",
              ""name"": ""Champions (1975) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8069"",
              ""name"": ""Champions (1975) #7""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8070"",
              ""name"": ""Champions (1975) #8""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8056"",
              ""name"": ""Champions (1975) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8060"",
              ""name"": ""Champions (1975) #14""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8062"",
              ""name"": ""Champions (1975) #16""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 76,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009318/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13896"",
              ""name"": ""Age of X: Universe (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13863"",
              ""name"": ""Amazing Spider-Man/Ghost Rider - Motorstorm (2011 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/354"",
              ""name"": ""Avengers (1998 - 2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1991"",
              ""name"": ""Avengers (1963 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1737"",
              ""name"": ""Avengers Assemble Vol. 3 (2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16325"",
              ""name"": ""Captain America and Bucky (2011 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1565"",
              ""name"": ""Captain Universe: Universal Heroes (2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2001"",
              ""name"": ""Champions (1975 - 1978)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1720"",
              ""name"": ""Champions Classic Vol. 1 (2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1721"",
              ""name"": ""Champions Classic Vol. 2 (2007)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24096"",
              ""name"": ""Damnation: Johnny Blaze - Ghost Rider (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2002"",
              ""name"": ""Daredevil (1964 - 1998)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/20006"",
              ""name"": ""Deathlok (1991)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/26664"",
              ""name"": ""Decades: Marvel In The -70s - Legion Of Monsters (2019)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3741"",
              ""name"": ""Doctor Strange, Sorcerer Supreme (1988 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/25782"",
              ""name"": ""Doctor Strange: Damnation (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24016"",
              ""name"": ""Doctor Strange: Damnation (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1552"",
              ""name"": ""Essential Ghost Rider Vol. 1 (2005)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1427"",
              ""name"": ""Essential Peter Parker, the Spectacular Spider-Man Vol. (2005)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 406,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009318/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4062"",
              ""name"": ""1 of 1"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4064"",
              ""name"": ""Ghost Rider (2005) #2"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4066"",
              ""name"": ""Cover #4066"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4068"",
              ""name"": ""Ghost Rider (2005) #1"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4069"",
              ""name"": ""1 of 6 - The Road to Damnation"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4071"",
              ""name"": ""Ghost Rider (2005) #4"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4072"",
              ""name"": ""4 of 6 - The Road to Damnation"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4073"",
              ""name"": ""Cover #4073"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4075"",
              ""name"": ""Ghost Rider (2005) #3"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4076"",
              ""name"": ""3 of 6 - The Road to Damnation"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4077"",
              ""name"": ""Ghost Rider (2005) #5"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4078"",
              ""name"": ""5 of 6 - The Road to Damnation"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4079"",
              ""name"": ""Ghost Rider (2005) #6"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4080"",
              ""name"": ""6 of 6 - The Road to Damnation"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6064"",
              ""name"": ""1 of 5 - Vicious Cycle"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6068"",
              ""name"": ""2 of 5 - Vicious Cycle"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6070"",
              ""name"": ""3 of 5 - Vicious Cycle"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6072"",
              ""name"": ""4 of 5 - Vicious Cycle"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6074"",
              ""name"": ""5 of 5 - Vicious Cycle"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6076"",
              ""name"": ""1 of 2 - Death of Blaze"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 6,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009318/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/303"",
              ""name"": ""Age of X""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/59"",
              ""name"": ""Shadowland""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/219"",
              ""name"": ""Siege of Darkness""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/277"",
              ""name"": ""World War Hulk""
            }
          ],
          ""returned"": 6
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009318/ghost_rider_johnny_blaze?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Ghost_Rider_%28John_Blaze%29?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009318/ghost_rider_johnny_blaze?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009368,
        ""name"": ""Iron Man"",
        ""description"": ""Wounded, captured and forced to build a weapon by his enemies, billionaire industrialist Tony Stark instead created an advanced suit of armor to save his life and escape captivity. Now with a new outlook on life, Tony uses his money and intelligence to make the world a safer, better place as Iron Man."",
        ""modified"": ""2016-09-28T12:08:19-0400"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/9/c0/527bb7b37ff55"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009368"",
        ""comics"": {
          ""available"": 2561,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009368/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43495"",
              ""name"": ""A+X (2012) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43506"",
              ""name"": ""A+X (2012) #7""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/24348"",
              ""name"": ""Adam: Legend of the Blue Marvel (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/22461"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/22856"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/23733"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30090"",
              ""name"": ""Age of Heroes (2010) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/33566"",
              ""name"": ""Age of Heroes (2010) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30092"",
              ""name"": ""Age of Heroes (2010) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30093"",
              ""name"": ""Age of Heroes (2010) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67603"",
              ""name"": ""Age of Innocence: The Rebirth of Iron Man (1996) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38524"",
              ""name"": ""Age of X: Universe (2011) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38523"",
              ""name"": ""Age of X: Universe (2011) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/21280"",
              ""name"": ""All-New Iron Manual (2008) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/55363"",
              ""name"": ""All-New, All-Different Avengers (2015) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/55364"",
              ""name"": ""All-New, All-Different Avengers (2015) #11""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12653"",
              ""name"": ""Alpha Flight (1983) #113""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12668"",
              ""name"": ""Alpha Flight (1983) #127""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/55311"",
              ""name"": ""The Amazing Spider-Man (2015) #13""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/55312"",
              ""name"": ""The Amazing Spider-Man (2015) #14""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 625,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009368/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16450"",
              ""name"": ""A+X (2012 - 2014)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/7524"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6079"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9790"",
              ""name"": ""Age of Heroes (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24380"",
              ""name"": ""Age of Innocence: The Rebirth of Iron Man (1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13896"",
              ""name"": ""Age of X: Universe (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/4897"",
              ""name"": ""All-New Iron Manual (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/20443"",
              ""name"": ""All-New, All-Different Avengers (2015 - 2016)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2116"",
              ""name"": ""Alpha Flight (1983 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/454"",
              ""name"": ""Amazing Spider-Man (1999 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2984"",
              ""name"": ""Amazing Spider-Man Annual (1964 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/15540"",
              ""name"": ""Amazing Spider-Man Annual (2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1489"",
              ""name"": ""AMAZING SPIDER-MAN VOL. 10: NEW AVENGERS TPB (2005)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/318"",
              ""name"": ""Amazing Spider-Man Vol. 6 (2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/23446"",
              ""name"": ""Amazing Spider-Man: Worldwide Vol. 2 (2017)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6056"",
              ""name"": ""ANNIHILATION CLASSIC HC (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/14818"",
              ""name"": ""Annihilators: Earthfall (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/14779"",
              ""name"": ""Art of Marvel Studios TPB Slipcase (2011 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9792"",
              ""name"": ""Astonishing Spider-Man/Wolverine (2010 - 2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6792"",
              ""name"": ""Astonishing Tales (2009)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 3873,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009368/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/670"",
              ""name"": ""X-MEN (2004) #186"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/892"",
              ""name"": ""THOR (1998) #81"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/960"",
              ""name"": ""3 of ?"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/982"",
              ""name"": ""Interior #982"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/984"",
              ""name"": ""Interior #984"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/986"",
              ""name"": ""Interior #986"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/988"",
              ""name"": ""Interior #988"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/990"",
              ""name"": ""Interior #990"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/992"",
              ""name"": ""Interior #992"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/994"",
              ""name"": ""Interior #994"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/996"",
              ""name"": ""Interior #996"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/998"",
              ""name"": ""Interior #998"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1000"",
              ""name"": ""Interior #1000"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1002"",
              ""name"": ""AVENGERS DISASSEMBLED TIE-IN! Still reeling from recent traumas, Iron Man must face off against his evil doppelganger. Meanwhile"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1004"",
              ""name"": ""\""THE SINGULARITY\"" CONCLUSION! PART 4 (OF 4) The battle rages on between Iron Man and his doppelganger, but only one of them can "",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1018"",
              ""name"": ""Amazing Spider-Man (1999) #500"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1024"",
              ""name"": ""Avengers (1998) #80"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1026"",
              ""name"": ""Avengers (1998) #81"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1041"",
              ""name"": ""Avengers (1998) #502"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1051"",
              ""name"": ""Interior #1051"",
              ""type"": ""interiorStory""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 31,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009368/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/116"",
              ""name"": ""Acts of Vengeance!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/303"",
              ""name"": ""Age of X""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/231"",
              ""name"": ""Armor Wars""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/233"",
              ""name"": ""Atlantis Attacks""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/234"",
              ""name"": ""Avengers Disassembled""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/310"",
              ""name"": ""Avengers VS X-Men""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/296"",
              ""name"": ""Chaos War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/239"",
              ""name"": ""Crossing""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/318"",
              ""name"": ""Dark Reign""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/245"",
              ""name"": ""Enemy of the State""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/249"",
              ""name"": ""Fatal Attractions""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/251"",
              ""name"": ""House of M""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/315"",
              ""name"": ""Infinity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/29"",
              ""name"": ""Infinity War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/317"",
              ""name"": ""Inhumanity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/255"",
              ""name"": ""Initiative""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/37"",
              ""name"": ""Maximum Security""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/154"",
              ""name"": ""Onslaught""
            }
          ],
          ""returned"": 20
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009368/iron_man?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Iron_Man_(Anthony_Stark)?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009368/iron_man?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1011081,
        ""name"": ""Ka-Zar"",
        ""description"": """",
        ""modified"": ""2016-02-04T12:31:16-0500"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/9/40/4dcc503738d3d"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1011081"",
        ""comics"": {
          ""available"": 124,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1011081/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/16889"",
              ""name"": ""Amazing Spider-Man Annual (1964) #15""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/61926"",
              ""name"": ""Astonishing Tales (1970) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/57810"",
              ""name"": ""Astonishing Tales (1970) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/57811"",
              ""name"": ""Astonishing Tales (1970) #13""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/61927"",
              ""name"": ""Astonishing Tales (1970) #15""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/61928"",
              ""name"": ""Astonishing Tales (1970) #16""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/61929"",
              ""name"": ""Astonishing Tales (1970) #17""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/61930"",
              ""name"": ""Astonishing Tales (1970) #18""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/61931"",
              ""name"": ""Astonishing Tales (1970) #19""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/61932"",
              ""name"": ""Astonishing Tales (1970) #20""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67769"",
              ""name"": ""Avengers (2018) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12791"",
              ""name"": ""Captain America (1998) #31""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7795"",
              ""name"": ""Captain America (1968) #414""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7796"",
              ""name"": ""Captain America (1968) #415""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7797"",
              ""name"": ""Captain America (1968) #416""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7798"",
              ""name"": ""Captain America (1968) #417""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/66191"",
              ""name"": ""Daredevil Epic Collection: Mike Murdock Must Die! (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/76334"",
              ""name"": ""Fantastic Four: The Prodigal Sun (2019) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/36051"",
              ""name"": ""Incredible Hulks (2010) #623""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/36050"",
              ""name"": ""Incredible Hulks (2010) #624""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 45,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1011081/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2984"",
              ""name"": ""Amazing Spider-Man Annual (1964 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16431"",
              ""name"": ""Astonishing Tales (1970)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1996"",
              ""name"": ""Captain America (1968 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1997"",
              ""name"": ""Captain America (1998 - 2002)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24001"",
              ""name"": ""Daredevil Epic Collection: Mike Murdock Must Die! (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/27383"",
              ""name"": ""Fantastic Four: The Prodigal Sun (2019)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/8842"",
              ""name"": ""Incredible Hulks (2010 - 2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/12968"",
              ""name"": ""Incredible Hulks: Planet Savage TPB (2010 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13316"",
              ""name"": ""Ka-Zar (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/22691"",
              ""name"": ""Ka-Zar (1974 - 1977)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/14243"",
              ""name"": ""Ka-Zar (1997 - 1999)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24014"",
              ""name"": ""Ka-Zar Annual (1997)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16424"",
              ""name"": ""Ka-Zar the Savage (1981 - 1984)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/11893"",
              ""name"": ""Klaws of the Panther (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24002"",
              ""name"": ""Lockjaw (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3049"",
              ""name"": ""Marvel Atlas (2007 - 2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2815"",
              ""name"": ""Marvel Comics Presents (2007 - 2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2039"",
              ""name"": ""Marvel Comics Presents (1988 - 1995)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/5387"",
              ""name"": ""Marvel Masterworks: Golden Age Marvel Comics Vol. 3 (2008)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 140,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1011081/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/740"",
              ""name"": ""Uncanny X-Men (1963) #458"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/741"",
              ""name"": ""4 of 5 - World-s End"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/743"",
              ""name"": ""5 of 5 - World-s End"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/13544"",
              ""name"": ""Cover #13544"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/13546"",
              ""name"": ""Cover #13546"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/15377"",
              ""name"": ""Uncanny X-Men (1963) #10"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/15604"",
              ""name"": ""Uncanny X-Men (1963) #62"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/15606"",
              ""name"": ""Uncanny X-Men (1963) #63"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/18148"",
              ""name"": ""Captain America (1968) #414"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/18149"",
              ""name"": ""Escape From AIM Isle"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/18150"",
              ""name"": ""Captain America (1968) #415"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/18151"",
              ""name"": ""Savage Landings"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/18152"",
              ""name"": ""Captain America (1968) #416"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/18153"",
              ""name"": ""Savage Land Showdown"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/18154"",
              ""name"": ""Captain America (1968) #417"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/18155"",
              ""name"": ""Termination Day"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/18361"",
              ""name"": ""The Lost Land of Ka-Zar!"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/18362"",
              ""name"": ""The Monster and the Man-Beast!"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/20771"",
              ""name"": ""What if...Ka-Zar...were a Middle-Aged Accountant instead of a Savage?"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/23069"",
              ""name"": ""This Is A Savage Land"",
              ""type"": """"
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 1,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1011081/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/269"",
              ""name"": ""Secret Invasion""
            }
          ],
          ""returned"": 1
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1011081/ka-zar?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Ka-Zar_%28Kevin_Plunder%29?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1011081/ka-zar?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009407,
        ""name"": ""Loki"",
        ""description"": """",
        ""modified"": ""2017-08-21T16:45:34-0400"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/d/90/526547f509313"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009407"",
        ""comics"": {
          ""available"": 371,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009407/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43504"",
              ""name"": ""A+X (2012) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/29735"",
              ""name"": ""All-Winners Squad: Band of Heroes (2011) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12713"",
              ""name"": ""Alpha Flight (1983) #50""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/290"",
              ""name"": ""Amazing Spider-Man (1999) #503""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/361"",
              ""name"": ""Amazing Spider-Man (1999) #504""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/2970"",
              ""name"": ""AMAZING SPIDER-MAN VOL. 7: BOOK OF EZEKIEL TPB (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/1333"",
              ""name"": ""Amazing Spider-Man Vol. 7: The Book of Ezekiel (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67308"",
              ""name"": ""Amazing-Spider-Man: Worldwide Vol. 8 (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/73993"",
              ""name"": ""Asgardians Of The Galaxy Vol. 2: War Of The Realms (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38990"",
              ""name"": ""Vengeance (2011) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17751"",
              ""name"": ""Avengers (1996) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/6951"",
              ""name"": ""Avengers (1963) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67756"",
              ""name"": ""Avengers (2018) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17757"",
              ""name"": ""Avengers (1996) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17758"",
              ""name"": ""Avengers (1996) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67762"",
              ""name"": ""Avengers (2018) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17760"",
              ""name"": ""Avengers (1996) #6""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7321"",
              ""name"": ""Avengers (1963) #7""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17762"",
              ""name"": ""Avengers (1996) #8""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17763"",
              ""name"": ""Avengers (1996) #9""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 154,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009407/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16450"",
              ""name"": ""A+X (2012 - 2014)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9865"",
              ""name"": ""All-Winners Squad: Band of Heroes (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2116"",
              ""name"": ""Alpha Flight (1983 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/454"",
              ""name"": ""Amazing Spider-Man (1999 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1292"",
              ""name"": ""AMAZING SPIDER-MAN VOL. 7: BOOK OF EZEKIEL TPB (2005)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1291"",
              ""name"": ""Amazing Spider-Man Vol. 7: The Book of Ezekiel (2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24322"",
              ""name"": ""Amazing-Spider-Man: Worldwide Vol. 8 (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/26672"",
              ""name"": ""Asgardians Of The Galaxy Vol. 2: War Of The Realms (2019)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1991"",
              ""name"": ""Avengers (1963 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3621"",
              ""name"": ""Avengers (1996 - 1997)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1988"",
              ""name"": ""Avengers Annual (1967 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/15274"",
              ""name"": ""Avengers Origins: Thor (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/20060"",
              ""name"": ""Avengers Vs (2015)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3462"",
              ""name"": ""Avengers West Coast: Darker than Scarlet (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/23777"",
              ""name"": ""Avengers: Tales to Astonish (2017)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9020"",
              ""name"": ""Avengers: The Origin (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2115"",
              ""name"": ""Black Panther (1998 - 2003)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6804"",
              ""name"": ""Black Panther (2009 - 2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13689"",
              ""name"": ""Cap and Thor! Avengers (2010)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 438,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009407/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1663"",
              ""name"": ""Amazing Spider-Man (1999) #503"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1664"",
              ""name"": ""Interior #1664"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1665"",
              ""name"": ""Amazing Spider-Man (1999) #504"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1666"",
              ""name"": ""Interior #1666"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1731"",
              ""name"": ""Cover #1731"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1732"",
              ""name"": ""Interior #1732"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1733"",
              ""name"": ""Cover #1733"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1734"",
              ""name"": ""Interior #1734"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1735"",
              ""name"": ""Cover #1735"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1736"",
              ""name"": ""Interior #1736"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1737"",
              ""name"": ""Cover for Loki (2004) #4"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1738"",
              ""name"": ""The conclusion to the epic adventure that dares you to see Asgardian legend through the eyes of Loki! You knew it was coming. Th"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2380"",
              ""name"": ""Interior #2380"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2391"",
              ""name"": ""Cover #2391"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/5286"",
              ""name"": ""1 of 1 - Thor"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6762"",
              ""name"": ""Loki 1-4"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/10969"",
              ""name"": ""JOURNEY INTO MYSTERY (1952) #108"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/10989"",
              ""name"": ""Loki the Evil One!  Thor-s Eternal Enemy!"",
              ""type"": ""pinup""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/10994"",
              ""name"": ""Journey Into Mystery (1952) #113"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/10995"",
              ""name"": ""A World Gone Mad"",
              ""type"": ""interiorStory""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 9,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009407/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/116"",
              ""name"": ""Acts of Vengeance!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/233"",
              ""name"": ""Atlantis Attacks""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/320"",
              ""name"": ""Axis""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/318"",
              ""name"": ""Dark Reign""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/319"",
              ""name"": ""Original Sin""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/271"",
              ""name"": ""Secret Wars II""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/309"",
              ""name"": ""Shattered Heroes""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/273"",
              ""name"": ""Siege""
            }
          ],
          ""returned"": 9
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009407/loki?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Loki?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009407/loki?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009466,
        ""name"": ""Namor"",
        ""description"": """",
        ""modified"": ""2014-02-27T11:15:08-0500"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/e/90/50febf4ae101d"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009466"",
        ""comics"": {
          ""available"": 292,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009466/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/571"",
              ""name"": ""4 (2004) #8""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/556"",
              ""name"": ""4 (2004) #9""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/1550"",
              ""name"": ""4 Vol. 2: The Stuff of Nightmares (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/24348"",
              ""name"": ""Adam: Legend of the Blue Marvel (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/23562"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37996"",
              ""name"": ""Age of X: Alpha (2010) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/24371"",
              ""name"": ""All Winners Comics 70th Anniversary Special (2009) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12690"",
              ""name"": ""Alpha Flight (1983) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12701"",
              ""name"": ""Alpha Flight (1983) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/29211"",
              ""name"": ""Avengers (2010) #8""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/29212"",
              ""name"": ""Avengers (2010) #9""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67766"",
              ""name"": ""Avengers (2018) #9""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/29196"",
              ""name"": ""Avengers (2010) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/29197"",
              ""name"": ""Avengers (2010) #11""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38617"",
              ""name"": ""Avengers (2010) #11 (CAPTAIN AMERICA 70TH ANNIVERSARY VARIANT)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/29198"",
              ""name"": ""Avengers (2010) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/4956"",
              ""name"": ""Avengers (1998) #84""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7133"",
              ""name"": ""Avengers (1963) #262""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7134"",
              ""name"": ""Avengers (1963) #263""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7137"",
              ""name"": ""Avengers (1963) #266""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 111,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009466/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/725"",
              ""name"": ""4 (2004 - 2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1253"",
              ""name"": ""4 Vol. 2: The Stuff of Nightmares (2005)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/7524"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6079"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13603"",
              ""name"": ""Age of X: Alpha (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/7534"",
              ""name"": ""All Winners Comics 70th Anniversary Special (2009)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2116"",
              ""name"": ""Alpha Flight (1983 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1991"",
              ""name"": ""Avengers (1963 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/354"",
              ""name"": ""Avengers (1998 - 2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9085"",
              ""name"": ""Avengers (2010 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/4864"",
              ""name"": ""Avengers/Invaders (2008 - 2009)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2115"",
              ""name"": ""Black Panther (1998 - 2003)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6804"",
              ""name"": ""Black Panther (2009 - 2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1996"",
              ""name"": ""Captain America (1968 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24503"",
              ""name"": ""Captain America (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/485"",
              ""name"": ""Captain America (2002 - 2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16325"",
              ""name"": ""Captain America and Bucky (2011 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/22747"",
              ""name"": ""Captain America and the Avengers: The Complete Collection (2017)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/8213"",
              ""name"": ""Captain America: Reborn (2009 - 2010)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 336,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009466/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1007"",
              ""name"": ""Cover #1007"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1127"",
              ""name"": ""Cover #1127"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1606"",
              ""name"": ""WEAPON X (2002) #14"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1907"",
              ""name"": ""Cover #1907"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2009"",
              ""name"": ""Cover #2009"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2043"",
              ""name"": ""Cover #2043"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2231"",
              ""name"": ""WOLVERINE (2003) #44"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2233"",
              ""name"": ""WOLVERINE (2003) #45"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3051"",
              ""name"": ""4 (2004) #9"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3053"",
              ""name"": ""4 (2004) #8"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3884"",
              ""name"": ""3 of 6 - Reflections"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4223"",
              ""name"": ""Cover #4223"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6057"",
              ""name"": ""Marvel 1602: Fantastick Four (2006) #3"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6058"",
              ""name"": ""Interior #6058"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6059"",
              ""name"": ""Marvel 1602: Fantastick Four (2006) #4"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6060"",
              ""name"": ""4 of 5 - Fantastick Four - 5XLS"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6062"",
              ""name"": ""5 of 5 - Fantastick Four - 5XLS"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/6238"",
              ""name"": ""1 of 5 - 5XLS"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/7847"",
              ""name"": ""Marvel 1602: Fantastick Four (2006) #5"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/7906"",
              ""name"": ""2 of 5 - 5 XLS"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 16,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009466/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/116"",
              ""name"": ""Acts of Vengeance!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/303"",
              ""name"": ""Age of X""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/233"",
              ""name"": ""Atlantis Attacks""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/310"",
              ""name"": ""Avengers VS X-Men""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/318"",
              ""name"": ""Dark Reign""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/315"",
              ""name"": ""Infinity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/317"",
              ""name"": ""Inhumanity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/311"",
              ""name"": ""Marvel NOW!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/336"",
              ""name"": ""Secret Empire""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/269"",
              ""name"": ""Secret Invasion""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/271"",
              ""name"": ""Secret Wars II""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/309"",
              ""name"": ""Shattered Heroes""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/308"",
              ""name"": ""X-Men: Regenesis""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/306"",
              ""name"": ""X-Men: Schism""
            }
          ],
          ""returned"": 16
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009466/namor?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Sub-Mariner?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009466/namor?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009480,
        ""name"": ""Odin"",
        ""description"": """",
        ""modified"": ""2014-06-12T16:01:36-0400"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/3/00/539a06a64b262"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009480"",
        ""comics"": {
          ""available"": 212,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009480/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7321"",
              ""name"": ""Avengers (1963) #7""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17753"",
              ""name"": ""Avengers (1996) #11""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67769"",
              ""name"": ""Avengers (2018) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7336"",
              ""name"": ""Avengers (1963) #83""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7087"",
              ""name"": ""Avengers (1963) #220""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/41109"",
              ""name"": ""Avengers Origins: Thor (2011) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17850"",
              ""name"": ""Balder the Brave (1985) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12616"",
              ""name"": ""Black Panther (1998) #47""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38703"",
              ""name"": ""Captain America (2004) #617 (THOR HOLLYWOOD VARIANT)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/64526"",
              ""name"": ""Deadpool: World-s Greatest Vol. 9 - Deadpool in Space (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8555"",
              ""name"": ""Earth X (1999) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/8551"",
              ""name"": ""Earth X (1999) #12""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/4241"",
              ""name"": ""Earth X (New (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/39520"",
              ""name"": ""Essential Thor Vol. 5 (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/13075"",
              ""name"": ""Fantastic Four (1961) #262""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17461"",
              ""name"": ""FANTASTIC FOUR VISIONARIES: JOHN BYRNE VOL. 4 TPB (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38926"",
              ""name"": ""Fear Itself (2010) #1 (Immomen Variant)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38975"",
              ""name"": ""Fear Itself (2010) #1 (Ff 50th Anniversary Variant)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38962"",
              ""name"": ""Fear Itself (2010) #1 (Blank Cover Variant)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/38928"",
              ""name"": ""Fear Itself (2010) #2""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 83,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009480/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3621"",
              ""name"": ""Avengers (1996 - 1997)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1991"",
              ""name"": ""Avengers (1963 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/15274"",
              ""name"": ""Avengers Origins: Thor (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3625"",
              ""name"": ""Balder the Brave (1985)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2115"",
              ""name"": ""Black Panther (1998 - 2003)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/832"",
              ""name"": ""Captain America (2004 - 2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/23510"",
              ""name"": ""Deadpool: World-s Greatest Vol. 9 - Deadpool in Space (2017)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/378"",
              ""name"": ""Earth X (1999)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1806"",
              ""name"": ""Earth X (New (2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/14475"",
              ""name"": ""Essential Thor Vol. 5 (2011 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2121"",
              ""name"": ""Fantastic Four (1961 - 1998)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3293"",
              ""name"": ""FANTASTIC FOUR VISIONARIES: JOHN BYRNE VOL. 4 TPB (2001 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13691"",
              ""name"": ""Fear Itself (2010 - 2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/15595"",
              ""name"": ""Fear Itself 7.2: Thor (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2032"",
              ""name"": ""Journey Into Mystery (1952 - 1966)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/14764"",
              ""name"": ""Journey Into Mystery (2011 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/13569"",
              ""name"": ""Journey Into Mystery (1996 - 1998)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2302"",
              ""name"": ""JOURNEY INTO MYSTERY ANNUAL 1 (1965)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/10830"",
              ""name"": ""Loki (2010 - 2011)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 260,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009480/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/10993"",
              ""name"": ""The Coming of Loki"",
              ""type"": """"
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/10994"",
              ""name"": ""Journey Into Mystery (1952) #113"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/10995"",
              ""name"": ""A World Gone Mad"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11000"",
              ""name"": ""Journey Into Mystery (1952) #115"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11001"",
              ""name"": ""The Vengeance of the Thunder God"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11003"",
              ""name"": ""Journey Into Mystery (1952) #116"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11004"",
              ""name"": ""The Trial of the Gods"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11006"",
              ""name"": ""Journey Into Mystery (1952) #117"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11007"",
              ""name"": ""Into the Blaze of Battle!"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11009"",
              ""name"": ""Journey Into Mystery (1952) #118"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11010"",
              ""name"": ""To Kill a Thunder God"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11012"",
              ""name"": ""Journey Into Mystery (1952) #119"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11013"",
              ""name"": ""The Day of the Destroyer"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11022"",
              ""name"": ""Journey Into Mystery (1952) #120"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11023"",
              ""name"": ""With My Hammer In Hand"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11028"",
              ""name"": ""Journey Into Mystery (1952) #122"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11029"",
              ""name"": ""Where Mortals Fear To Tread!"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11031"",
              ""name"": ""Journey Into Mystery (1952) #123"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11032"",
              ""name"": ""While a Universe Trembles"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/11034"",
              ""name"": ""Journey Into Mystery (1952) #124"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 7,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009480/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/116"",
              ""name"": ""Acts of Vengeance!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/235"",
              ""name"": ""Blood and Thunder""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/37"",
              ""name"": ""Maximum Security""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/154"",
              ""name"": ""Onslaught""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/319"",
              ""name"": ""Original Sin""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/309"",
              ""name"": ""Shattered Heroes""
            }
          ],
          ""returned"": 7
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009480/odin?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Odin?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009480/odin?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009583,
        ""name"": ""She-Hulk (Jennifer Walters)"",
        ""description"": ""Seriously wounded, young lawyer Jennifer Walters was given a blood transfusion by her cousin Bruce Banner. Usually in better control of her powers and temper than the Hulk, She-Hulk has been a high profile New York lawyer as well as an upstanding member of both the Avengers and Fantastic Four."",
        ""modified"": ""2014-01-24T18:10:30-0500"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/7/20/527bb5d64599e"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009583"",
        ""comics"": {
          ""available"": 451,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009583/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/58636"",
              ""name"": ""Marvel New Year-s Eve Special Infinite Comic (2017) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56017"",
              ""name"": ""A-Force (2016) #6""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56018"",
              ""name"": ""A-Force (2016) #7""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56019"",
              ""name"": ""A-Force (2016) #8""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56021"",
              ""name"": ""A-Force (2016) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/24348"",
              ""name"": ""Adam: Legend of the Blue Marvel (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/22461"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37405"",
              ""name"": ""Age of Ultron (2013) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/37406"",
              ""name"": ""Age of Ultron (2013) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/24053"",
              ""name"": ""All-New Savage She-Hulk (2009) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/24252"",
              ""name"": ""All-New Savage She-Hulk (2009) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/60276"",
              ""name"": ""All-New, All-Different Avengers Annual (2016) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12725"",
              ""name"": ""Alpha Flight (1983) #61""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12651"",
              ""name"": ""Alpha Flight (1983) #111""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12668"",
              ""name"": ""Alpha Flight (1983) #127""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/29321"",
              ""name"": ""Atlantis Attacks (2011) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/29322"",
              ""name"": ""Atlantis Attacks (DM Only) (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67002"",
              ""name"": ""Avengers (2018) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17490"",
              ""name"": ""Avengers (1998) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67311"",
              ""name"": ""Avengers (2018) #2""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 146,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009583/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/20606"",
              ""name"": ""A-Force (2016)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/7524"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6079"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/17318"",
              ""name"": ""Age of Ultron (2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/7231"",
              ""name"": ""All-New Savage She-Hulk (2009)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/22190"",
              ""name"": ""All-New, All-Different Avengers Annual (2016)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2116"",
              ""name"": ""Alpha Flight (1983 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/10030"",
              ""name"": ""Atlantis Attacks (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/10031"",
              ""name"": ""Atlantis Attacks (DM Only) (2011)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/354"",
              ""name"": ""Avengers (1998 - 2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1991"",
              ""name"": ""Avengers (1963 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1988"",
              ""name"": ""Avengers Annual (1967 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1340"",
              ""name"": ""Avengers Assemble (2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1737"",
              ""name"": ""Avengers Assemble Vol. 3 (2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1816"",
              ""name"": ""Avengers Assemble Vol. 4 (2007)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2384"",
              ""name"": ""Avengers Classic (2007 - 2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3971"",
              ""name"": ""Avengers Fairy Tales (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/158"",
              ""name"": ""Avengers Vol. 1: World Trust (2003)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/227"",
              ""name"": ""Avengers Vol. 2: Red Zone (2003)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 523,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009583/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/698"",
              ""name"": ""UNCANNY X-MEN (1963) #435"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1054"",
              ""name"": ""Avengers (1998) #72"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1947"",
              ""name"": ""Avengers (1998) #78"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1949"",
              ""name"": ""Avengers (1998) #79"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2092"",
              ""name"": ""Interior #2092"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2249"",
              ""name"": ""UNCANNY X-MEN (1963) #436"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2326"",
              ""name"": ""Avengers (1998) #74"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3130"",
              ""name"": ""1 of 1 - Hercules"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3132"",
              ""name"": ""Interior #3132"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3134"",
              ""name"": ""Interior #3134"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3136"",
              ""name"": ""Interior #3136"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3138"",
              ""name"": ""Interior #3138"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3140"",
              ""name"": ""Interior #3140"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3142"",
              ""name"": ""\""SPACE CASES\"" As a superhuman lawyer, SHE-HULK has tried some of the strangest cases on Earth... but all of that is about to cha"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3144"",
              ""name"": ""\""ENGAGEMENT RING\"" PART 2 (OF 2) A titanic tale of foxy boxing in outer space! Yes, FOXY BOXING! On a planet where might makes ri"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3145"",
              ""name"": ""1 of 3 - Titania"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3146"",
              ""name"": ""1 of 3 - Titania"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3148"",
              ""name"": ""2 of 3 - Titania"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3150"",
              ""name"": ""3 of 3 - Titania"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/4125"",
              ""name"": ""3 of 3 - Titannus War"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 15,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009583/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/116"",
              ""name"": ""Acts of Vengeance!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/314"",
              ""name"": ""Age of Ultron""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/233"",
              ""name"": ""Atlantis Attacks""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/296"",
              ""name"": ""Chaos War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/318"",
              ""name"": ""Dark Reign""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/297"",
              ""name"": ""Fall of the Hulks""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/29"",
              ""name"": ""Infinity War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/37"",
              ""name"": ""Maximum Security""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/269"",
              ""name"": ""Secret Invasion""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/270"",
              ""name"": ""Secret Wars""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/271"",
              ""name"": ""Secret Wars II""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/277"",
              ""name"": ""World War Hulk""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/280"",
              ""name"": ""X-Tinction Agenda""
            }
          ],
          ""returned"": 15
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009583/she-hulk_jennifer_walters?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/She-Hulk_(Jennifer_Walters)?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009583/she-hulk_jennifer_walters?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009664,
        ""name"": ""Thor"",
        ""description"": ""As the Norse God of thunder and lightning, Thor wields one of the greatest weapons ever made, the enchanted hammer Mjolnir. While others have described Thor as an over-muscled, oafish imbecile, he-s quite smart and compassionate.  He-s self-assured, and he would never, ever stop fighting for a worthwhile cause."",
        ""modified"": ""2019-02-06T18:10:24-0500"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/d/d0/5269657a74350"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009664"",
        ""comics"": {
          ""available"": 1749,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009664/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/43506"",
              ""name"": ""A+X (2012) #7""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30090"",
              ""name"": ""Age of Heroes (2010) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/33566"",
              ""name"": ""Age of Heroes (2010) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30092"",
              ""name"": ""Age of Heroes (2010) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/30093"",
              ""name"": ""Age of Heroes (2010) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/46852"",
              ""name"": ""Alpha: Big Time (2013) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12637"",
              ""name"": ""Alpha Flight (1983) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12725"",
              ""name"": ""Alpha Flight (1983) #61""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/12668"",
              ""name"": ""Alpha Flight (1983) #127""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/6748"",
              ""name"": ""The Amazing Spider-Man (1963) #339""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/277"",
              ""name"": ""Amazing Spider-Man (1999) #500""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/5808"",
              ""name"": ""Amazing Spider-Man (1999) #538""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/16904"",
              ""name"": ""Amazing Spider-Man Annual (1964) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/16890"",
              ""name"": ""Amazing Spider-Man Annual (1964) #16""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/1262"",
              ""name"": ""Amazing Spider-Man Vol. 6 (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/39896"",
              ""name"": ""Art of Marvel Studios TPB Slipcase (Hardcover)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/32769"",
              ""name"": ""Astonishing Thor (2010) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/33652"",
              ""name"": ""Astonishing Thor (2010) #1 (FOILOGRAM VARIANT)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/32771"",
              ""name"": ""Astonishing Thor (2010) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/32774"",
              ""name"": ""Astonishing Thor (2010) #3""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 501,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009664/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/16450"",
              ""name"": ""A+X (2012 - 2014)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9790"",
              ""name"": ""Age of Heroes (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2116"",
              ""name"": ""Alpha Flight (1983 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/17650"",
              ""name"": ""Alpha: Big Time (2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/454"",
              ""name"": ""Amazing Spider-Man (1999 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/2984"",
              ""name"": ""Amazing Spider-Man Annual (1964 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/318"",
              ""name"": ""Amazing Spider-Man Vol. 6 (2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/14779"",
              ""name"": ""Art of Marvel Studios TPB Slipcase (2011 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9858"",
              ""name"": ""Astonishing Thor (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/744"",
              ""name"": ""Astonishing X-Men (2004 - 2013)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/22547"",
              ""name"": ""Avengers (2016 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9085"",
              ""name"": ""Avengers (2010 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/354"",
              ""name"": ""Avengers (1998 - 2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1991"",
              ""name"": ""Avengers (1963 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3621"",
              ""name"": ""Avengers (1996 - 1997)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9859"",
              ""name"": ""Avengers & the Infinity Gauntlet (2010)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9086"",
              ""name"": ""Avengers Academy (2010 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/26448"",
              ""name"": ""Avengers Annual (2001)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1988"",
              ""name"": ""Avengers Annual (1967 - 1994)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 2657,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009664/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/876"",
              ""name"": ""THOR (1998) #76"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/877"",
              ""name"": ""Interior #877"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/879"",
              ""name"": ""Interior #879"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/880"",
              ""name"": ""THOR (1998) #77"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/881"",
              ""name"": ""Interior #881"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/882"",
              ""name"": ""THOR (1998) #83"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/883"",
              ""name"": ""Interior #883"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/884"",
              ""name"": ""THOR (1998) #82"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/885"",
              ""name"": ""Interior #885"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/886"",
              ""name"": ""THOR (1998) #78"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/887"",
              ""name"": ""Interior #887"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/888"",
              ""name"": ""THOR (1998) #79"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/889"",
              ""name"": ""Interior #889"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/890"",
              ""name"": ""THOR (1998) #80"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/891"",
              ""name"": ""Interior #891"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/892"",
              ""name"": ""THOR (1998) #81"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/893"",
              ""name"": ""Interior #893"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/894"",
              ""name"": ""THOR (1998) #84"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/895"",
              ""name"": ""AVENGERS DISASSEMBLED TIE-IN! “RAGNAROK” PART 4 (OF 6) What makes a god? Is it birthright, is it happenstance, or is it in the m"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/896"",
              ""name"": ""THOR (1998) #85"",
              ""type"": ""cover""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 27,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009664/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/116"",
              ""name"": ""Acts of Vengeance!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/233"",
              ""name"": ""Atlantis Attacks""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/234"",
              ""name"": ""Avengers Disassembled""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/310"",
              ""name"": ""Avengers VS X-Men""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/235"",
              ""name"": ""Blood and Thunder""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/296"",
              ""name"": ""Chaos War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/318"",
              ""name"": ""Dark Reign""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/246"",
              ""name"": ""Evolutionary War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/252"",
              ""name"": ""Inferno""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/315"",
              ""name"": ""Infinity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/29"",
              ""name"": ""Infinity War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/317"",
              ""name"": ""Inhumanity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/311"",
              ""name"": ""Marvel NOW!""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/37"",
              ""name"": ""Maximum Security""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/263"",
              ""name"": ""Mutant Massacre""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/154"",
              ""name"": ""Onslaught""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/319"",
              ""name"": ""Original Sin""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/336"",
              ""name"": ""Secret Empire""
            }
          ],
          ""returned"": 20
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/characters/1009664/thor/featured?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Thor_(Thor_Odinson)?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009664/thor?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      },
      {
        ""id"": 1009707,
        ""name"": ""Wasp"",
        ""description"": ""When Janet Van Dyne-s father died, she convinced her father-s associate Hank Pym to give her a supply of \""Pym particles\""; Pym also subjected her to a procedure which granted her the ability to, upon shrinking, grow wings and fire blasts of energy, which she called her \""wasp-s stings.\"""",
        ""modified"": ""2016-02-29T10:44:27-0500"",
        ""thumbnail"": {
          ""path"": ""http://i.annihil.us/u/prod/marvel/i/mg/9/c0/5390dfd5ef165"",
          ""extension"": ""jpg""
        },
        ""resourceURI"": ""http://gateway.marvel.com/v1/public/characters/1009707"",
        ""comics"": {
          ""available"": 412,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009707/comics"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/24348"",
              ""name"": ""Adam: Legend of the Blue Marvel (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/22461"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/56436"",
              ""name"": ""All-New Wolverine (2015) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/55367"",
              ""name"": ""All-New, All-Different Avengers (2015) #14""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67706"",
              ""name"": ""Ant-Man & the Wasp: Living Legends (2018) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/67309"",
              ""name"": ""Ant-Man and the Wasp Adventures (Digest)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/41530"",
              ""name"": ""Ant-Man: Astonishing Origins (Trade Paperback)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17490"",
              ""name"": ""Avengers (1998) #1""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17501"",
              ""name"": ""Avengers (1998) #2""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17757"",
              ""name"": ""Avengers (1996) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17512"",
              ""name"": ""Avengers (1998) #3""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17523"",
              ""name"": ""Avengers (1998) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17758"",
              ""name"": ""Avengers (1996) #4""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7299"",
              ""name"": ""Avengers (1963) #5""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/7332"",
              ""name"": ""Avengers (1963) #8""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17763"",
              ""name"": ""Avengers (1996) #9""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/6953"",
              ""name"": ""Avengers (1963) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17752"",
              ""name"": ""Avengers (1996) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17491"",
              ""name"": ""Avengers (1998) #10""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/comics/17753"",
              ""name"": ""Avengers (1996) #11""
            }
          ],
          ""returned"": 20
        },
        ""series"": {
          ""available"": 159,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009707/series"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/6079"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/7524"",
              ""name"": ""Adam: Legend of the Blue Marvel (2008)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/20682"",
              ""name"": ""All-New Wolverine (2015 - 2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/20443"",
              ""name"": ""All-New, All-Different Avengers (2015 - 2016)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24415"",
              ""name"": ""Ant-Man & the Wasp: Living Legends (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24323"",
              ""name"": ""Ant-Man and the Wasp Adventures (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24418"",
              ""name"": ""Ant-Man: Astonishing Origins (2018)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/3621"",
              ""name"": ""Avengers (1996 - 1997)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/354"",
              ""name"": ""Avengers (1998 - 2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/24229"",
              ""name"": ""Avengers (2018 - Present)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9085"",
              ""name"": ""Avengers (2010 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1991"",
              ""name"": ""Avengers (1963 - 1996)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/9086"",
              ""name"": ""Avengers Academy (2010 - 2012)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/26448"",
              ""name"": ""Avengers Annual (2001)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1988"",
              ""name"": ""Avengers Annual (1967 - 1994)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1340"",
              ""name"": ""Avengers Assemble (2004)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/15373"",
              ""name"": ""Avengers Assemble (2012 - 2014)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1496"",
              ""name"": ""Avengers Assemble Vol. 2 (2005)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1737"",
              ""name"": ""Avengers Assemble Vol. 3 (2006)""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/series/1816"",
              ""name"": ""Avengers Assemble Vol. 4 (2007)""
            }
          ],
          ""returned"": 20
        },
        ""stories"": {
          ""available"": 468,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009707/stories"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1024"",
              ""name"": ""Avengers (1998) #80"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1026"",
              ""name"": ""Avengers (1998) #81"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1040"",
              ""name"": ""Avengers (1998) #502"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1500"",
              ""name"": ""Interior #1500"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1649"",
              ""name"": ""Avengers (1998) #77"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1947"",
              ""name"": ""Avengers (1998) #78"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/1949"",
              ""name"": ""Avengers (1998) #79"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2299"",
              ""name"": ""ULTIMATES (2002) #13"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2359"",
              ""name"": ""1 of"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/2723"",
              ""name"": ""ULTIMATES 2 (2004) #1"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3023"",
              ""name"": ""Avengers: Earth-s Mightiest Heroes (2004) #1"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3024"",
              ""name"": ""1 of 8 - 8XLS"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3025"",
              ""name"": ""Avengers: Earth-s Mightiest Heroes (2004) #2"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3026"",
              ""name"": ""2 of 8 - 8XLS"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3027"",
              ""name"": ""Avengers: Earth-s Mightiest Heroes (2004) #3"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3028"",
              ""name"": ""3 of 8 - 8XLS"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3029"",
              ""name"": ""Avengers: Earth-s Mightiest Heroes (2004) #4"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3030"",
              ""name"": ""4 of 8 - 8XLS"",
              ""type"": ""interiorStory""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3031"",
              ""name"": ""Avengers: Earth-s Mightiest Heroes (2004) #5"",
              ""type"": ""cover""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/stories/3032"",
              ""name"": ""5 of 8 - 8XLS"",
              ""type"": ""interiorStory""
            }
          ],
          ""returned"": 20
        },
        ""events"": {
          ""available"": 14,
          ""collectionURI"": ""http://gateway.marvel.com/v1/public/characters/1009707/events"",
          ""items"": [
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/234"",
              ""name"": ""Avengers Disassembled""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/238"",
              ""name"": ""Civil War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/239"",
              ""name"": ""Crossing""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/318"",
              ""name"": ""Dark Reign""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/302"",
              ""name"": ""Fear Itself""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/315"",
              ""name"": ""Infinity""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/29"",
              ""name"": ""Infinity War""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/255"",
              ""name"": ""Initiative""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/37"",
              ""name"": ""Maximum Security""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/154"",
              ""name"": ""Onslaught""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/336"",
              ""name"": ""Secret Empire""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/269"",
              ""name"": ""Secret Invasion""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/270"",
              ""name"": ""Secret Wars""
            },
            {
              ""resourceURI"": ""http://gateway.marvel.com/v1/public/events/271"",
              ""name"": ""Secret Wars II""
            }
          ],
          ""returned"": 14
        },
        ""urls"": [
          {
            ""type"": ""detail"",
            ""url"": ""http://marvel.com/comics/characters/1009707/wasp?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""wiki"",
            ""url"": ""http://marvel.com/universe/Wasp?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          },
          {
            ""type"": ""comiclink"",
            ""url"": ""http://marvel.com/comics/characters/1009707/wasp?utm_campaign=apiRef&utm_source=2abbe5ce987d39d120336577c150eac4""
          }
        ]
      }
    ]
    ";

            return JsonConvert.DeserializeObject<List<Character>>(jsonString).ToArray();
        }
    }
}
