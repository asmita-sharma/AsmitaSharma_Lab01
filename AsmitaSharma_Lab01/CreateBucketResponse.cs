using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsmitaSharma_Lab01
{
    class CreateBucketResponse
    {
        private string bucketName;
        public string RequestId;

        private string name; // field

        

        public string BucketName   // property
        {
            get { return bucketName; }   // get method
            set { bucketName = value; }  // set method
        }

        public string RequestID  // property
        {
            get { return RequestId; }   // get method
            set { RequestId = value; }  // set method
        }
    }
}
