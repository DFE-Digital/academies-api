FROM cypress/base:18.16.1

COPY ./cypress ./cypress
COPY cypress.json .
COPY package-lock.json package-lock.json
COPY package.json package.json

RUN npm install
ENTRYPOINT ["npm", "run", "cy:run"]