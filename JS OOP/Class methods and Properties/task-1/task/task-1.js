'use strict';

class listNode {
    constructor(value) {
        this._valueOfNode = value;
        this.nextNode = null;
    }

    get valueOfNode() {
        return this._valueOfNode;
    }
    set valueOfNode(value) {
        if (isNaN(value)) {
            throw new Error('The value of the node should be defined.');
        }
        this._valueOfNode = value;
    }

    get nextNode() {
        return this._next;
    }
    set nextNode(value) {
        if (isNaN(value)) {
            throw new Error('The value of the node should be defined.');
        }
        this._next = value;
    }
}

var LinkedList = ( function (listNode) {
    function getNodeAtIndex(ind) {
        let currNode;

        if (ind < 0 || this._length - 1 < ind) {
            currNode = null;
        }
        else {
            let i = 0;
            currNode = this._head;

            while (i < ind) {
                currNode = currNode.nextNode;
                i += 1;
            }
        }

        return currNode;
    }
    class LinkedList {
        constructor() {
            this._length = 0;
            this._head = null;
        }

        get lengthOfList() {
            return this._length;
        }

        get firstNode() {
            if (this._head !== null) {
                return this._head._valueOfNode;
            }
            else {
                return null;
            }
        }

        get lastNode() {
            var lastIndex=this._length-1;
            
            if(this._head!==null){
                return getNodeAtIndex.call(this, lastIndex)._valueOfNode;
            }
            else{
                return null;
            }
        }

        append(...elements) {
            var elementsToAdd=elements;
            elementsToAdd.map(function(item){
                return new listNode(item);
            });

            let last;
            let lastInd = this._length - 1;
            if (this._head === null) {
                this._head = elementsToAdd[0];
                last = this._head;
            }
            else {
                last = getNodeAtIndex.call(this, lastInd);
                last.nextNode = elementsToAdd[0];
                last = last.nextNode;
            }

            this._length += 1;

            for (let i = 1, len = elementsToAdd.length; i < len; i += 1) {
                let currentItem = elementsToAdd[i];
                last.nextNode = currentItem;
                last = last.nextNode;
                this._length += 1;
            }

            return this;
        }

        prepend(...elements) {
            var elementsToAdd=elements;
            elementsToAdd.map(function(item){
                return new listNode(item);
            });

            let next = this._head;
            this._head = elementsToAdd[0];
            this._length += 1;

            let curr = this._head;
            for (let i = 1, len = elementsToAdd.length; i < len; i += 1) {
                curr.nextNode = elementsToAdd[i];
                curr = curr.nextNode;
                this._length += 1;
            }

            curr.nextNode = next;
            return this;
        }

        insert(index, ...elements) {
            this.splice(index, 0, elements);
            return this;
        }

        at(index, value) {
            if (value === 'undefined') {
                return getNodeAtIndex.call(this, index)._valueOfNode;
            }
            else {
                if(index===0){
                    this._head._valueOfNode=value;
                }
                else{
                    getNodeAtIndex.call(this, index).valueOfNode=value;
                }
                return this;
            }
        }

        removeAt(index) {
            this.splice(index, 1);
        }

        toString() {
            let current = this._head;
            let str = '';

            while (current.nextNode !== null) {
                str += current._valueOfNode + ' -> ';
                current = current.nextNode;
            }

            str += current._valueOfNode;

            return str;
        }

        toArray() {
            let arr = [];
            for (let node of this) {
                arr.push(node);
            }

            return arr;
        }

        [Symbol.iterator]() {
            let current = this._head;

            return {
                next: function () {
                    if (current === null) {
                        return {
                            done: true 
                        };
                    }
                    else {
                        let data = current._valueOfNode;
                        current = current.nextNode;
                        return {
                            value: data,
                            done: false
                        };
                    }
                }
            };
        }
    }

    return LinkedList;
})(listNode);

module.exports = LinkedList;