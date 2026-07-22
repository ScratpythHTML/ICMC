# AGENTS.md

Guidance for coding agents working in this repository. Humans should also read `README.md`.

## What this is

The website for the **Imperial College Mountaineering Club (ICMC)** — a static site
built with [Hugo](https://gohugo.io/) (extended). Most content is trip reports and
expedition write-ups spanning from the 1950s to today, plus a handful of informational
pages (FAQs, beginners, links, membership).

- **Generator:** Hugo (extended, `min 0.87.0`; CI builds with 0.145.0)
- **Theme:** [hugo-theme-stack](https://github.com/CaiJimmy/hugo-theme-stack) v3, pulled
  in as a Hugo Module (see `go.mod`). Files under `layouts/` and `assets/` are **local
  overrides** of the theme — edit these to change appearance/behaviour, not the module.
- **Content:** Markdown under `content/`
- **Deploy:** GitHub Actions → GitHub Pages

## Local development

```bash
hugo server            # live-reload dev server at http://localhost:1313
hugo --gc --minify     # production build into ./public
```

Run these from the repo root. Node deps (`flag-icons`) install with `npm ci`; Hugo mounts
them as assets (see `config.yaml`). A devcontainer is provided (`.devcontainer/`).

> Note: `debug.sh` and `netlify.toml` reference an `exampleSite/` directory that does not
> exist in this repo — they are leftovers from the theme starter. Ignore them; build from
> the root.

## Configuration

Config is split across two places, both loaded and merged by Hugo:

- `config.yaml` (root) — Hugo modules, params, image processing, analytics, author
- `config/_default/*.toml` — site title, menus (`menu.toml`), social links (`config.toml`),
  markup, languages, permalinks

The `baseurl` in `config/_default/config.toml` is a placeholder; the deployed base URL is
injected by CI (`--baseURL`), so don't rely on it locally.

## Repository layout

```
content/          Markdown content
  post/<year>/<name>/index.md   Trip reports (main content; mainSection = "post")
  page/           Standalone pages (faqs, beginnerPage, links, privacy, whatsapp, ...)
  categories/     Category definitions (accident, expedition, summer-tour, ...)
layouts/          Local overrides of theme templates (partials, shortcodes)
  shortcodes/     Custom shortcodes: gallery, membership_email, whatsapp, youtube, video, ...
assets/
  ts/             TypeScript for site behaviour (gallery, search, colorScheme, menu)
  scss/           Styles
  img/avatar.png  Main website logo
static/           Files served as-is (favicon.png, documents, jquery)
archetypes/post.md   Template used by `hugo new`
themes/hugo-scroll   Git submodule (largely unused; primary theme is the Hugo module)
```

## Creating a trip report (the most common task)

```bash
hugo new content content/post/<year>/<name>/index.md
```

Then, in `content/post/<year>/<name>/`:

1. Fill in front matter following `archetypes/post.md` — `title`, `description`, `date`,
   `categories`, `tags`, and `locations` (ISO 3166-1 alpha-2 codes for the country flags).
2. Put photos in an `images/` subfolder; the `{{< gallery >}}` shortcode picks them up.
3. Add a cover image named `cover.jpg` next to `index.md` (or point `image:` at another
   filename in the front matter).

Keep front-matter field names as-is — templates and widgets read `categories`, `tags`,
`locations`, and `image` directly.

## Deployment

- Pushing to **`main`** triggers `.github/workflows/hugo.yaml` (Live deployment → GitHub Pages).
- Pushing to / PRing **`master`** triggers `.github/workflows/deploy.yml` (Dev deployment
  → `gh-pages` branch).
- Deploys can also be run manually from the Actions tab (workflow_dispatch).

Note the branch mismatch: the default branch is `master`, but the production ("Live")
workflow deploys from `main`. Confirm the intended branch before assuming a push will go live.

## Conventions & gotchas

- Prefer editing files under `layouts/` and `assets/` to customise the theme; the theme
  module itself is a dependency and shouldn't be forked in place.
- Generated/ignored dirs: `public/`, `resources/`, `node_modules/` (see `.gitignore`) —
  never commit these.
- The membership form (`layouts/shortcodes/membership_email.html`) posts to a Google Apps
  Script endpoint and uses hCaptcha. The email template and endpoint live in Google
  (script.google.com) — see `README.md` for the links.
- Logos: main site logo is `assets/img/avatar.png`, browser favicon is `static/favicon.png`.
