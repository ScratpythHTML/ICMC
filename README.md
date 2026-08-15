# ICMC Website — Adding a Trip Report (No Coding Required)

Welcome! This guide shows you how to turn a **Word document** (like a trip report or
expedition write-up) into a page on the [Imperial College Mountaineering Club](https://github.com/icmountaineering/icmc_website)
website — with an AI assistant doing the technical work for you.

You do **not** need to know how to code. You'll be copying and pasting a few commands and
letting an AI assistant called **opencode** do the rest. Take it one step at a time. 🏔️

---

## What you'll be doing, in a nutshell

1. Install a couple of free tools (opencode and VS Code) — a one-time setup.
2. Download a copy of the website to your computer.
3. Drop your Word document into the folder.
4. Ask the AI assistant to turn your document into a website page.
5. Preview the page on your own computer.
6. Publish it to the live website.

---

## Step 1 — Install the tools (one-time setup)

You'll need a few free programs. You only have to do this once, ever.

### a) Windows only — install Git first

**On a Mac? Skip straight to step (b).**

Windows doesn't come with the tools this guide needs, so install Git for Windows first —
it includes a terminal called **Git Bash** that makes everything below work the same way
it does on a Mac.

👉 **https://git-scm.com/download/win**

Download it, open the file, and click "Next" through the installer with the default
options. When it's done, open the **Start menu**, type `Git Bash`, and press Enter.

> **Important:** every time this guide says "terminal", use **Git Bash** — not PowerShell
> or Command Prompt. The commands won't work in those.

### b) Install opencode (the AI assistant)

Open a terminal:

- **Mac:** press `Cmd + Space`, type `Terminal`, and press Enter.
- **Windows:** open the **Start menu**, type `Git Bash`, and press Enter.

Copy and paste this line into the terminal, then press Enter:

```bash
curl -fsSL https://opencode.ai/install | bash
```

Wait for it to finish. This installs the AI assistant you'll use later.

> **Mac tip:** if a box pops up asking to install "command line developer tools", click
> **Install** and wait for it to finish, then run the line above again.

### c) Install VS Code (a friendly editor)

VS Code is a free program that lets you see the website files and open a terminal in one
place. Download and install it from:

👉 **https://code.visualstudio.com/Download?_exp_download=fb315fc982**

Open the file after it downloads and follow the installer's prompts (just keep clicking
"Continue" / "Next" with the default options).

---

## Step 2 — Download a copy of the website

This makes a copy of the whole website on your computer so you can add to it safely.

1. Open **VS Code**.
2. Open a terminal inside VS Code: from the top menu choose **Terminal → New Terminal**.
   - **Windows:** click the small **`∨`** arrow next to the `+` on the right of the
     terminal panel and choose **Git Bash**. (VS Code opens PowerShell by default, and the
     commands below won't work there.)
3. Copy and paste this line and press Enter:

```bash
git clone https://github.com/icmountaineering/icmc_website.git
```

4. When it finishes, open the folder in VS Code: **File → Open Folder…**, then choose the
   `icmc_website` folder that was just created.

You now have the whole website on your computer. 🎉

---

## Step 3 — Add your Word document

Find your trip report Word document (for example `Scotland Winter Trip.docx`) on your
computer.

**Drag and drop it** into the `icmc_website` folder shown in the left-hand sidebar of
VS Code. That's it — the AI assistant can now read it.

> Tip: A photo or two makes a trip report much nicer. If you have pictures, drag those into
> the folder too, and mention them in the prompt below.

---

## Step 4 — Ask the AI to build the page

Now the fun part. In the VS Code terminal, start the AI assistant by typing:

```bash
opencode
```

Then type:

```bash
\connect
```

and choose OpenCode Zen.

It will ask you to paste in an API key - you can find a free one here: https://opencode.ai/zen.

Then choose Big Pickle (or any free one) as the model.

When it's ready, **copy the prompt below, paste it in, and press Enter.** Replace
`YOUR-DOCUMENT-NAME.docx` with the actual name of your file, and set the year to the year
of the trip.

```
I've added a Word document called "lakes.docx" to this repository.

Please turn it into a new trip report page on the website:

1. Read the document and any images I've added.
2. Create the post at content/post/2026/<short-name>/index.md, where <short-name> is a
   short, lowercase, hyphenated name based on the trip (e.g. "scotland-winter").
   Use 2026 as the year folder unless the trip clearly happened in a different year.
3. Follow the existing template in archetypes/post.md for the front matter: fill in the
   title, description, date, categories, tags, and the locations field (use the correct
   ISO 3166-1 alpha-2 country code so the right flag shows).
4. Put the write-up text from the document into the body of the post.
5. If I added photos, place them in an "images" folder next to the post and display them
   using the {{< gallery >}} shortcode, and set one of them as cover.jpg.
6. Keep the tone and formatting consistent with the other posts under content/post/.

When you're done, tell me the folder you created so I can preview it.
```

The assistant will read your document and create the page for you. If it asks a question,
just answer in plain English. If something doesn't look right, tell it what to change — you
can chat with it like a person.

---

## Step 5 — Preview the website on your computer

Before publishing, you can see exactly how your page will look. The easiest way is to ask
the assistant to do it. In the same `opencode` session, paste:

```
Please start the local Hugo preview server so I can view the site in my browser, and tell
me the web address to open. If Hugo isn't installed, please install it first.
```

The assistant will start a preview and give you a web address — usually:

👉 **http://localhost:1313**

Open that address in your web browser (Chrome, Safari, Edge, etc.). Find your new trip
report and check that it looks the way you want. The preview updates automatically as
changes are made, so you can keep tweaking until you're happy.

When you're finished previewing, go back to the terminal and press `Ctrl + C` to stop it.

---

## Step 6 — Publish to the live website

Once you're happy with how it looks, you'll save your work and publish it.

### a) Save and upload your changes

In the VS Code terminal (press `Ctrl + C` first if the preview is still running), paste
these three lines one at a time, pressing Enter after each:

```bash
git add .
git commit -m "Add new trip report"
git push
```

This uploads your new page to GitHub (where the website lives).

> Not sure about this bit? You can also just ask opencode: *"Please save and push my
> changes to GitHub with a sensible message."*

### b) Make it go live

Publishing to the live site is done with one click on GitHub:

1. Go to the **Actions** page:
   👉 **https://github.com/icmountaineering/icmc_website/actions/workflows/hugo.yaml**
2. Click the **"Run workflow"** button on the right.
3. Confirm by clicking the green **"Run workflow"** button in the little pop-up.

Wait a couple of minutes. When the tick turns green ✅, your trip report is live on the
website for everyone to see. 🎉

---

## Need help?

- You can ask **opencode** almost anything in plain English — it knows this website.
- Technical details for developers live in **[AGENTS.md](AGENTS.md)**.
- Older developer notes are kept in **[OLD_README.md](OLD_README.md)**.

Happy climbing, and thanks for sharing your trip! ⛰️
