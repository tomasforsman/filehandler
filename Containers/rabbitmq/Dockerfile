FROM rabbitmq:latest

WORKDIR /usr/local/bin/
ADD ./init.sh .
RUN chmod +x ./init.sh

CMD ["./init.sh"]