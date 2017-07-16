import { browser, element, by,By, ElementFinder } from 'protractor';

describe('Initial Page E2E Tests',
    () => {

        beforeEach(() => {


        });


        it('on initial load there should 2 list groups',
            () => {

                browser.get('http://localhost:49574/')
                    .then(() => {
                        let groups = element.all(by.className("list-group"));
                        expect(groups.count()).toBe(2);

                    });

            });

        it('on initial load in male group  the first item should be Garfield',
            () => {

                browser.get('http://localhost:49574/')
                    .then(() => {

                        let firstItem = element(by.id('Male_item_0'));
                        expect(firstItem.getText()).toBe('Garfield');

                    });

            });

        it('on initial load in female group  the first item should be Garfield',
            () => {

                browser.get('http://localhost:49574/')
                    .then(() => {

                        let firstItem = element(by.id('Female_item_0'));
                        expect(firstItem.getText()).toBe('Garfield');

                    });

            });

        it('after clicking Togglesort button in Male group the first item should be Tom when sorting is desc',
            () => {

                browser.get('http://localhost:49574/')
                    .then(() => {

                        element(by.id('sort-btn')).click();
                        let firstItem = element(by.id('Male_item_0'));
                        expect(firstItem.getText()).toBe('Tom');

                    });

            });

        it('after clicking Togglesort button in female group the first item should be Tom when sorting is desc',
            () => {

                browser.get('http://localhost:49574/')
                    .then(() => {

                        element(by.id('sort-btn')).click();
                        let firstItem = element(by.id('Female_item_0'));
                        expect(firstItem.getText()).toBe('Tabby');

                    });

            });


    });