const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = "https://localhost:7281";

const context =  [
  "/todo",
  "/notificationHub"
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use(appProxy);
};
