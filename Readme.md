# Instructions
* Make sure you have the docker container for windows installed and you're using linux images (the docker tray menu should show 'Swith to Windows containers'. DO NOT Switch to Windows)
  
![Linux Containers](images/docker_linux.png)
  
* Make sure the ports used in docker-compose.yml is free on your computer
* run this command: 
* ``` docker-compose -f docker-compose.yml up -d --build```
# To do:
* ~~POC RabbitMQ on container~~
* ~~Review pluralsight course~~
* ~~POC publisher with MassTransit~~
* ~~POC subscriber with MassTransit~~
* ~~Containerize all microservices~~
* Connection resiliency
    * if the subscriber container fails to start, it's because rabbitmq is not up. Remove (NOT stop) the subscriber container and run the docker-compose again 

# Notes:
- This project is inspired by :
    -    http://looselycoupledlabs.com/2015/07/masstransit-3-update-a-simple-publishsubscribe-example/
