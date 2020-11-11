FROM mcr.microsoft.com/mssql/server:2017-latest

# Install node/npm
RUN apt-get -y update  && \
    apt-get install -y curl && \
    curl -sL https://deb.nodesource.com/setup_6.x | bash - && \
    apt-get install -y nodejs

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

EXPOSE 1433/tcp

# Bundle app source
COPY . /usr/src/app

# Grant permissions for the import-data script to be executable
RUN chmod +x /usr/src/app/docker-import.sh

CMD /bin/bash ./docker-entrypoint.sh

