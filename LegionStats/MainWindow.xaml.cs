using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LegionStats
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PlayerNameToAdd.Text))
            {
                PlayersList.Items.Add(PlayerNameToAdd.Text);
                PlayerNameToAdd.Text = string.Empty;

            }

        }

        private void GetPlayersInfo(object sender, RoutedEventArgs e)
        {

            dynamic result;
            if (PlayersList.Items.Count > 0)
            {
                foreach (var player in PlayersList.Items)
                {
                    result = postPlayerInfo(player.ToString());

                }
            }


            PlayerInfoResult.Text = "";

        }

        private Result postPlayerInfo(string playerName)
        {

            Result ret = new Result();


            string query = @"{
                          player(playername: """ + playerName + @""" ) {
                            games(limit: 200) {
                              count
                              games {
                                ts
                                queuetype
                                gameDetails {
                                  workersPerWave
                                  incomePerWave
                                  unitsPerWave
                                  mercsSentPerWave
                                  ts
                                  playername
                                  gameresult
                                  overallElo
                                  legionSpell
                                }
                              }
                            }
                          }
                        }
                        ";

            GraphQLClient client = new GraphQLClient("https://api.legiontd2.com/graphql");
            client.DefaultRequestHeaders.Add("x-api-key", "4S4rneouPKr8TOhCygXZiNL9Ut0ZEKP2");

            GraphQLRequest rq = new GraphQLRequest();
            rq.Query = query;
            var aa = client.PostAsync(rq).Result;

            var e = (string) aa.Data.player.games.count;


            doQuery(query);



            return ret;


        }

        private Result doQuery(string query)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("x-api-key", "4S4rneouPKr8TOhCygXZiNL9Ut0ZEKP2");
                StringContent queryString = new StringContent("{\"query\":\"" + query.Replace("\r\n", "") + "\",\"variables\":null,\"operationName\":null}", Encoding.UTF8, "application/json");

                string url = "https://api.legiontd2.com/graphql";

                response = client.PostAsync(new Uri(url), queryString).Result;
            }

            string result = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Result>(result);
        }

    }
}
