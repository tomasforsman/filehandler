#!/usr/bin/env bash
set -e
(
count=0;
# Execute list_users until service is up and running
until timeout 5 rabbitmqctl list_users >/dev/null 2>/dev/null || (( count++ >= 60 )); do sleep 1; done;

# Enable plugins
rabbitmq-plugins enable rabbitmq_consistent_hash_exchange
rabbitmq-plugins enable rabbitmq_delayed_message_exchange
rabbitmq-plugins enable rabbitmq_management
rabbitmq-plugins enable rabbitmq_prometheus
rabbitmq-plugins enable rabbitmq_shovel
rabbitmq-plugins enable rabbitmq_shovel_management
rabbitmq-plugins enable rabbitmq_tracing

# Register user
if rabbitmqctl list_users | grep $RABBITMQ_USER > /dev/null
then
  echo "User '$RABBITMQ_USER' already exist, skipping user creation"
else
  echo "Creating user '$RABBITMQ_USER'..."
  rabbitmqctl add_user $RABBITMQ_USER $RABBITMQ_PASSWORD
  rabbitmqctl set_user_tags $RABBITMQ_USER administrator
  rabbitmqctl set_permissions -p / $RABBITMQ_USER ".*" ".*" ".*"
  echo "User '$RABBITMQ_USER' creation completed"
fi
) &

# Call original entrypoint
exec docker-entrypoint.sh rabbitmq-server $@