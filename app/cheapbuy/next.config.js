/** @type {import('next').NextConfig} */

const nextConfig = {
    serverRuntimeConfig: {
        //TODO: Enable CORS or run NextJS to use Local HTTPS
        cheapBuyApiURL: 'http://localhost:5078'//'https://localhost:7147'
    }
}

module.exports = nextConfig