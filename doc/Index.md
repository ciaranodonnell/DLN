﻿## DLog.NET

DLog is a Distributed Log style message broker written on the .NET Platform. 

## Current Plan

It is not currently intended to compete with Apache Kafka. 
It is more of a learning exercise for myself in the design and execution of a Distributed Log platform. 
As I learn more about the Kafka, Azure EventHubs, AWS Kinesis, and other messaging platforms like the AMQP standard.
I want to try and create a .NET based implementation of one of these that will run on .NET Core on Windows and Linux.

## Future Plans

If in the future the broker implementation is successful and stable, I will look to optimize and performance test it to see if I can achieve Kafka like performance.

My current understanding is that a well configured Kafka broker is IO bound so getting to that point should suffice. 