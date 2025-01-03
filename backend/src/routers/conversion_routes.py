const express = require("express");
const { cryptoToFiat, fiatToCrypto } = require("../protocols/conversion");

const router = express.Router();

router.post("/crypto-to-fiat", cryptoToFiat);
router.post("/fiat-to-crypto", fiatToCrypto);

module.exports = router;
