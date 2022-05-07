module.exports = {
    maximumFileSizeToCacheInBytes: 10485760,
    globDirectory: "../../bin/Debug/net5.0/publish/wwwroot",
    globPatterns: [
        '**/*.{html,json,js,css,png,ico,json,wasm,dll,pdb,eot,otf,woff,svg,ttf}'
    ],
    swDest: "../../bin/Debug/net5.0/publish/wwwroot/sw.js",
    navigateFallback: "/index.html",
    clientsClaim: true,
    runtimeCaching: [{
        urlPattern: "https://localhost:5003/api/conferences/",
        handler: "NetworkFirst",
        options: {
            cacheName: "conferencesApi",
            expiration: {
                maxAgeSeconds: 1000,
            },
        },
    }],
};