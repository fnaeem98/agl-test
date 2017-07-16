"use strict";

//var jasmineReporters=require()

exports.config = {
    //seleniumAddress: 'http://localhost:4444/wd/hub',
    //seleniumServerJar: './node_modules/protractor/selenium/selenium-server-standalone-2.39.0.jar',
    directConnect:true,
    specs: [
        'app/test/e2e/**/*.spec.js'
    ],

    seleniumArgs: ['-browserTimeout=60'],


    // Capabilities to be passed to the webdriver instance.
    capabilities: {
        'browserName': 'chrome'
    },
    framework: 'jasmine2',
    jasmineNodeOpts: {
        showColors: true, // Use colors in the command line report.
    },

    baseUrl: 'http://localhost:49574',
    allScriptsTimeout: 30000


};


