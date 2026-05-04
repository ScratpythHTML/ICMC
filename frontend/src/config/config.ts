interface IConfig {
    EndpointConfig: {
        Api: string;
    }
}

const localConfig: IConfig = require('./config.local.json');

export default localConfig;