/*
 * Handing the chosen document to the trip report builder.
 *
 * The document is picked in a modal on one page and used on another, so it has
 * to survive a navigation. IndexedDB stores File objects whole and has no
 * practical size limit here; sessionStorage would need base64 and tops out
 * around 5 MB, which a photo-heavy trip report passes easily.
 */
(function () {
    "use strict";

    var SUBMIT_URL = "/submit/";

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
        stashFile: stashFile,
        takeFile: takeFile,
        submitUrl: SUBMIT_URL
    };
}());
