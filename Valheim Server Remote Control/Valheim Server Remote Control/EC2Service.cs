using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Valheim_Server_Remote_Control
{
    public class EC2Service
    {
        public void StartServer()
        {
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(Config.AWSAccessKeyId, Config.AWSSecretAccessKey);
            var ec2 = new AmazonEC2Client(awsCredentials, Config.AWSRegionEndpoint);
            var startInstancesRequest = new StartInstancesRequest();
            startInstancesRequest.InstanceIds.Add(Config.AWSInstanceId);
            ec2.StartInstances(startInstancesRequest);
        }

        public void StopServer()
        {
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(Config.AWSAccessKeyId, Config.AWSSecretAccessKey);
            var ec2 = new AmazonEC2Client(awsCredentials, Config.AWSRegionEndpoint);
            var stopInstancesRequest = new StopInstancesRequest();
            stopInstancesRequest.InstanceIds.Add(Config.AWSInstanceId);
            ec2.StopInstances(stopInstancesRequest);
        }

        public string GetServerStatus()
        {
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(Config.AWSAccessKeyId, Config.AWSSecretAccessKey);
            var ec2 = new AmazonEC2Client(awsCredentials, Config.AWSRegionEndpoint);
            var statusRequest = new DescribeInstanceStatusRequest();
            statusRequest.InstanceIds.Add(Config.AWSInstanceId);
            statusRequest.IncludeAllInstances = true;
            var result  = ec2.DescribeInstanceStatus(statusRequest).InstanceStatuses;
            return result[0].InstanceState.Name.Value;
        }
    }
}
