/*
 * Password gate for the trip report builder.
 *
 * This keeps passers-by out of the submit page; it is not security. The site
 * is static, so everything here runs in the visitor's browser and anyone who
 * looks at the source can work around it. Do not put anything private behind
 * it. Storing the hash rather than the password only avoids printing the
 * password itself in the page source.
 */
(function () {
    "use strict";

    var PASSWORD_SHA256 = "4a3b40fd073286e1a5fd0e7da47af9fa1ad3982520bb333c0f6569395b475c69";
    var STORAGE_KEY = "icmc-submit-unlocked";
    var SUBMIT_URL = "/submit/";

    function hash(text) {
        var bytes = new TextEncoder().encode(text);
        return crypto.subtle.digest("SHA-256", bytes).then(function (buffer) {
            return Array.prototype.map.call(new Uint8Array(buffer), function (b) {
                return b.toString(16).padStart(2, "0");
            }).join("");
        });
    }

    function isUnlocked() {
        try {
            return sessionStorage.getItem(STORAGE_KEY) === PASSWORD_SHA256;
        } catch (e) {
            return false;
        }
    }

    function remember() {
        try {
            sessionStorage.setItem(STORAGE_KEY, PASSWORD_SHA256);
        } catch (e) {
            /* private browsing — the visitor just gets asked again */
        }
    }

    function check(value) {
        // crypto.subtle needs a secure context. The live site is HTTPS and
        // localhost counts as secure, so this only bites on plain-HTTP previews.
        if (!window.crypto || !crypto.subtle) {
            return Promise.reject(new Error("insecure-context"));
        }
        return hash(value).then(function (digest) {
            return digest === PASSWORD_SHA256;
        });
    }

    /* ------------------------------------------------------------------ *
     * Handing the chosen document to the builder page
     *
     * The document is picked in a modal on one page and used on another, so
     * it has to survive a navigation. IndexedDB stores File objects whole and
     * has no practical size limit here; sessionStorage would need base64 and
     * tops out around 5 MB, which a photo-heavy trip report passes easily.
     * ------------------------------------------------------------------ */

    var DB_NAME = "icmc-submit";
    var STORE = "pending";

    function openDatabase() {
        return new Promise(function (resolve, reject) {
            if (!window.indexedDB) {
                reject(new Error("no-indexeddb"));
                return;
            }
            var request = indexedDB.open(DB_NAME, 1);
            request.onupgradeneeded = function () {
                request.result.createObjectStore(STORE);
            };
            request.onsuccess = function () { resolve(request.result); };
            request.onerror = function () { reject(request.error); };
        });
    }

    function withStore(mode, action) {
        return openDatabase().then(function (db) {
            return new Promise(function (resolve, reject) {
                var tx = db.transaction(STORE, mode);
                var request = action(tx.objectStore(STORE));
                tx.oncomplete = function () {
                    db.close();
                    resolve(request && request.result);
                };
                tx.onerror = function () {
                    db.close();
                    reject(tx.error);
                };
            });
        });
    }

    function stashFile(file) {
        return withStore("readwrite", function (store) {
            return store.put(file, "docx");
        });
    }

    // Reading it also clears it, so a refresh does not silently reopen the
    // previous document.
    function takeFile() {
        return withStore("readwrite", function (store) {
            var request = store.get("docx");
            request.onsuccess = function () { store.delete("docx"); };
            return request;
        }).catch(function () {
            return null;
        });
    }

    window.icmcGate = {
        isUnlocked: isUnlocked,
        remember: remember,
        check: check,
        stashFile: stashFile,
        takeFile: takeFile,
        submitUrl: SUBMIT_URL,
        storageKey: STORAGE_KEY
    };
}());
