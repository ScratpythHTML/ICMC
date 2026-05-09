interface IConfig {
  EndpointConfig: {
    Api: string;
  };
}

const baseConfig: IConfig = require('./config.json');

let config: IConfig;

try {
  // Try to load the local config (gitignored)
  const localConfig = require('./config.local.json');
  config = { ...baseConfig, ...localConfig };
} catch (e) {
  // If local config doesn't exist (Production/EAS), use the base config
  config = baseConfig;
}

export default config;