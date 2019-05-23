import React from "react";
import { Route, Redirect } from "react-router-dom";
import Home from "../components/home";
import Privacy from "../components/privacy";
import Products from "../components/products";
import NewProduct from "../components/newproduct";
import CookieConsent from "react-cookie-consent";
import UpdateProduct from "../components/updatecomponent";

const ReactRouter = () => {
  return (
    <React.Fragment>
      <div className="container">
      <CookieConsent
          location="bottom"
          buttonText="I Accept"
          cookieName="consentcookie"
          style={{ background: "#2B373B" }}
          buttonStyle={{ color: "#4e503b", fontSize: "13px" }}
          expires={150}
      >
      This website uses cookies to enhance the user experience.
      </CookieConsent>
        <main role="main" className="pb-3">
          <Route exact path="/" component={Home} />
          <Route exact path="/privacy" component={Privacy} />
          <Route exact path="/products" component={Products} />
          <Route exact path="/newproduct" component={NewProduct} />
          <Route path="/update/:id" component={UpdateProduct} />
        </main>
      </div>
    </React.Fragment>
  );
};
export default ReactRouter;
