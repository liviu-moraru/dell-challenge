import React, { Component } from "react";
import Validation from "../validation";

class ProductList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
  }
  removeItem(items, id) {
    for(let i = 0; i < items.length; i++){
      if(items[i].id == id){
        items.splice(i,1);
        i--;
      }
    }
    return items;
  }
  deleteItem(item, e) {
    this.setState({
      isLoaded: false
    });
    fetch(`http://localhost:5000/api/products/${item}`, {
      method: 'delete'
    })
        .then( res => {
          var items = this.removeItem(this.state.items, item);

          this.setState({
            isLoaded: true,
            items: items
          })
        },
            error => {
              this.setState({
                isLoaded: true,
                error
              });
            });
  }
  componentDidMount() {
    fetch("http://localhost:5000/api/products")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result,
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      );
  }

  render() {
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
          <ul>
            {items.map(item => (
              <li key={item.id}>

                <a href={'products/edit/' + item.id}>{item.name} - {item.category}</a>
                <button onClick={(e) => this.deleteItem(item.id, e)}>Delete</button>
              </li>
            ))}
          </ul>
      );
    }
  }
}

class Products extends Component {
  render() {
    return (
      <React.Fragment>
        <h1 className="display-4">Products</h1>
        <ProductList />
        <Validation />
      </React.Fragment>
    );
  }
}
export default Products;
