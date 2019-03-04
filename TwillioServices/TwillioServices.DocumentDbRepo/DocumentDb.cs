using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TwillioServices.Interfaces;

namespace TwillioServices.DocumentDbRepo
{
    public class DocumentDb : IDocumentDb
    {
        static DocumentClient client;
        static readonly string endpointUrl = ConfigurationManager.AppSettings["DocDbEndPointUrl"].ToString();
        static readonly string authorizationKey = ConfigurationManager.AppSettings["DocDbAuthorizationKey"].ToString();
        static readonly string databaseName = ConfigurationManager.AppSettings["databaseName"].ToString();
        static readonly string collectionName = ConfigurationManager.AppSettings["collectionName"].ToString();
        public Chart GetPlanForToday(string id)
        {
            using (client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {

                // Set some common query options
                FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

                string query = String.Format("SELECT * FROM C WHERE C.id={0}", id);


                var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);

                Chart chart = client.CreateDocumentQuery<Chart>(collectionLink, new FeedOptions { EnableCrossPartitionQuery = true })
                                          .Where(so => so.id == id)
                                          .AsEnumerable()
                                          .FirstOrDefault();



                return chart;

            }
        }

        public List<Chart> GetAllData()
        {
            using (client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {

                // Set some common query options
                FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

                var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);

                var chart = client.CreateDocumentQuery<Chart>(collectionLink, new FeedOptions { EnableCrossPartitionQuery = true })

                                          .AsEnumerable().ToList<Chart>();

                return chart;

            }
        }

        public bool UpSertData(Chart chart)
        {
            try
            {
                using (client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
                {

                    FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };

                    string query = String.Format("SELECT * FROM C WHERE C.id={0}", chart.id);

                    var collectionLink = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);
                    var c = client.UpsertDocumentAsync(collectionLink, chart, new RequestOptions { PartitionKey = new Microsoft.Azure.Documents.PartitionKey(chart.pkey) }).Result;
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
          
        }
    }
}
