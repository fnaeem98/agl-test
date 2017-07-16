"use strict";
exports.__esModule = true;
var protractor_1 = require("protractor");
describe('Initial Page E2E Tests', function () {
    beforeEach(function () {
    });
    it('on initial load there should 2 list groups', function () {
        protractor_1.browser.get('http://localhost:49574/')
            .then(function () {
            var groups = protractor_1.element.all(protractor_1.by.className("list-group"));
            expect(groups.count()).toBe(2);
        });
    });
    it('on initial load in male group  the first item should be Garfield', function () {
        protractor_1.browser.get('http://localhost:49574/')
            .then(function () {
            var firstItem = protractor_1.element(protractor_1.by.id('Male_item_0'));
            expect(firstItem.getText()).toBe('Garfield');
        });
    });
    it('on initial load in female group  the first item should be Garfield', function () {
        protractor_1.browser.get('http://localhost:49574/')
            .then(function () {
            var firstItem = protractor_1.element(protractor_1.by.id('Female_item_0'));
            expect(firstItem.getText()).toBe('Garfield');
        });
    });
    it('after clicking Togglesort button in Male group the first item should be Tom when sorting is desc', function () {
        protractor_1.browser.get('http://localhost:49574/')
            .then(function () {
            protractor_1.element(protractor_1.by.id('sort-btn')).click();
            var firstItem = protractor_1.element(protractor_1.by.id('Male_item_0'));
            expect(firstItem.getText()).toBe('Tom');
        });
    });
    it('after clicking Togglesort button in female group the first item should be Tom when sorting is desc', function () {
        protractor_1.browser.get('http://localhost:49574/')
            .then(function () {
            protractor_1.element(protractor_1.by.id('sort-btn')).click();
            var firstItem = protractor_1.element(protractor_1.by.id('Female_item_0'));
            expect(firstItem.getText()).toBe('Tabby');
        });
    });
});
