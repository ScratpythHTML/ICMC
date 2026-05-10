# Local database

Create a local database with the following command:

```
docker run --name {choose_a_db_name} -e POSTGRES_PASSWORD={choose_a_password} -p 5432:5432 -d postgres:latest
```

Then, create a 'appsettings.local.json' file in the same directory and with the template of `appsettings.json` then fill in the credentials.

## GitHub Actions - Android Builds

A workflow is available to create Android App Bundle (.aab) builds using EAS CLI locally on GitHub Actions.

### Setup

1. Generate an [Expo Access Token](https://expo.dev/settings/access-tokens).
2. Add it as a secret to your GitHub repository named `EXPO_TOKEN`.

### Usage

1. Go to the **Actions** tab in GitHub.
2. Select **Android Preview Build**.
3. Click **Run workflow**.
4. Choose the build profile (`preview` or `production`).
5. Once finished, the `.aab` file will be available in the workflow artifacts.