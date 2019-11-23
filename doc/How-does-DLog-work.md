# How does DLog.NET work?

DLN is a Distributed Log style Message Broker. 
That means that it stores messages sequentially on disk like a log file.
It allows clients to publish new messages to the end of that log file.
It then also allows clients to Consume messages from that log file.

## Clustering

Currently the broker does not support clustering. 