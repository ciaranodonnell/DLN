# Broker Config

The BrokerConfig is the root of the configuration structure that gets passed to a new broker

## KnownTopicConfigs

This is a Dictionary of Topic names to Topic Configs. 
If someone publishes to a Topic that doesnt already exist, this will configure its creation.

If the broker is started and the topic already exists from a previous run, this configuration will be used going forward.
This allows you to reconfigure the rolling actions for Partition Segments

## DefaultTopicConfig

This is the default configuration for new Topics on the Broker.
If someone publishes to a topic that hasnt been specifically configured, this is the configuration that will be used. 

