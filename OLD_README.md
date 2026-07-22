# Developer notes

## Getting started (linux or macOS)
1. Install hugo (https://gohugo.io/getting-started/quick-start/)
2. Clone the repo locally (git@github.com:Covirt/ICMC.git)
3. Make changes to the website (see below)
4. Commit changes to a branch (git commit -m "what I just changed")
5. Push to github (git push origin main)
6. Deploy using GitHub actions (https://github.com/Covirt/ICMC/actions/workflows/hugo.yaml -> Run Workflow, from branch Master)
7. Check website updated correctly

## Updating logo
Change the files here:
- Main website logo: assets/img/avatar.png
- Browser icon logo: static/favicon.png

## Creating a new post
1. Create a new post in markdown using:
`hugo new content content/post/<year>/<name>/index.md`
2. Fill the template using the comments (title, description, date, country flag, labels/tags)
3. Add images in `content/post/<year>/<name>/images/`
4. Choose a cover, rename it to cover.jpg (or edit the header of the template with the correct filename) and place in `content/post/<year>/<name>/`

## Updating the membership email
The website calls a Google App scripts endpoint configured from this spreadsheet
https://docs.google.com/spreadsheets/d/1BDBZLxGG4sRoX28YOxWjuUrHXrAGP4rVIAKci6HErXc/edit?gid=1446695317#gid=1446695317

1. Go to https://script.google.com/u/0/home/projects/1flXO2HnDhQbLSACHu9yRcrfyWkwlJxq1CrOxEQOqQXXTyqaL-RNSaaOS/edit
2. Edit the file membershipEmailTemplate.html