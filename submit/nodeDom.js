/*
 * A very small HTML parser used only when convert.js runs under Node, where
 * there is no DOMParser. It handles exactly the subset mammoth emits:
 * block elements containing simple inline markup. The browser uses the real
 * DOMParser instead, so nothing here affects the published page.
 */

var VOID_ELEMENTS = { img: true, br: true, hr: true, input: true, meta: true, link: true };

var ENTITIES = {
    "&amp;": "&", "&lt;": "<", "&gt;": ">", "&quot;": '"',
    "&#39;": "'", "&apos;": "'", "&nbsp;": " "
};

function decodeEntities(text) {
    return text.replace(/&(?:[a-z]+|#\d+);/gi, function (entity) {
        if (ENTITIES[entity]) return ENTITIES[entity];
        var numeric = /^&#(\d+);$/.exec(entity);
        return numeric ? String.fromCharCode(parseInt(numeric[1], 10)) : entity;
    });
}

function createElement(tagName, attributes) {
    return {
        nodeType: 1,
        tagName: tagName,
        attributes: attributes,
        childNodes: [],
        getAttribute: function (name) {
            return Object.prototype.hasOwnProperty.call(this.attributes, name)
                ? this.attributes[name]
                : null;
        }
    };
}

function createText(value) {
    return { nodeType: 3, nodeValue: value, childNodes: [] };
}

function parseAttributes(source) {
    var attributes = {};
    var pattern = /([a-zA-Z_:][-a-zA-Z0-9_:.]*)(?:\s*=\s*(?:"([^"]*)"|'([^']*)'|([^\s"'>]+)))?/g;
    var match;
    while ((match = pattern.exec(source))) {
        var value = match[2] !== undefined ? match[2]
            : match[3] !== undefined ? match[3]
            : match[4] !== undefined ? match[4]
            : "";
        attributes[match[1].toLowerCase()] = decodeEntities(value);
    }
    return attributes;
}

function parse(html) {
    var root = createElement("div", {});
    var stack = [root];
    var pattern = /<\/?([a-zA-Z][a-zA-Z0-9]*)((?:[^>"']|"[^"]*"|'[^']*')*)>/g;
    var cursor = 0;
    var match;

    function current() {
        return stack[stack.length - 1];
    }

    function addText(text) {
        if (!text) return;
        var decoded = decodeEntities(text);
        if (decoded) current().childNodes.push(createText(decoded));
    }

    while ((match = pattern.exec(html))) {
        addText(html.slice(cursor, match.index));
        cursor = pattern.lastIndex;

        var tagName = match[1].toLowerCase();
        var isClosing = match[0].charAt(1) === "/";
        var isSelfClosing = /\/\s*$/.test(match[2]) || VOID_ELEMENTS[tagName];

        if (isClosing) {
            // Walk back to the matching open tag, tolerating unclosed markup.
            for (var i = stack.length - 1; i > 0; i--) {
                if (stack[i].tagName === tagName) {
                    stack.length = i;
                    break;
                }
            }
        } else {
            var element = createElement(tagName, parseAttributes(match[2]));
            current().childNodes.push(element);
            if (!isSelfClosing) stack.push(element);
        }
    }

    addText(html.slice(cursor));
    return root;
}

module.exports = { parse: parse };
