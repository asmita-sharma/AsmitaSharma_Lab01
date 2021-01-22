using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace AsmitaSharma_Lab01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name;
        string awsAccessKey = "AKIAYJ5X7MERCVV5QOGS";
        string awsSecreteKey = "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";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private static IAmazonS3 s3Client;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            s3Client = new AmazonS3Client(awsAccessKey, awsSecreteKey, RegionEndpoint.USEast1);
            CreateBucket(textBox1.Text).Wait();
            
        }

        //private static BasicAWSCredentials GetBasicCredentials()
        //{
        //    var builder = new ConfigurationBuilder
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);

        //    var accessID = builder.Build().GetSection("awsAccessKey").Value;
        //    var secretKey = builder.Build().GetSection("awsSecretKey").Value;
        //}

        private static async Task<CreateBucketResponse> CreateBucket(string bucketName)
        {
            var putBucketRequest = new PutBucketRequest
            {
                BucketName = bucketName,
                UseClientRegion = true
            };

            var response = await s3Client.PutBucketAsync(putBucketRequest);

            return new CreateBucketResponse
            {
                BucketName = bucketName,
                RequestId = response.ResponseMetadata.RequestId
            };

            MessageBox.Show("Bucket Created");
        }

    }
}
