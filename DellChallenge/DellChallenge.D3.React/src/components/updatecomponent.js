import React, { Component } from "react";
import Validation from "../validation";

class UpdateProduct extends Component {
    constructor() {
        super();
        this.state = {
            Name: "",
            Category: "",
            Success: false,
        };
        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    componentDidMount() {
        const { id } = this.props.match.params;
        fetch(`http://localhost:5000/api/products/${id}`, {
            method: "GET",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            },
            mode: "cors",
        })
            .then(res => res.json())
            .then(result => this.setState({
                Name: result.name,
                Category: result.category,
                Id: result.id
            }))
            .catch(err => console.log(err));

    }

    validateForm() {
        let msg = '';
        let valid = true;
        if(!this.state.Name)
        {
            msg += 'Please enter a name\n';
            valid = false;
        }
        if(!this.state.Category)
        {
            msg += 'Please enter a category\n';
            valid = false;
        }
        if(!valid)
        {
            alert(msg);
        }
        return valid;
    }

    handleSubmit = event => {
        event.preventDefault();
        if(!this.validateForm()) return;
        let postData = {
            Name: this.state.Name,
            Category: this.state.Category,

        };

        fetch(`http://localhost:5000/api/products/${this.state.Id}`, {
            method: "PUT",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            },
            mode: "cors",
            body: JSON.stringify(postData)
        })
            .then(res => res.json())
            .then(this.props.history.push('/products'))
            .catch(err => console.log(err));
    };

    handleInputChange = event => {
        const target = event.target;
        const value = target.type === "checkbox" ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    };

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <h4>Update Product</h4>
                <div className="form-group">
                    <label className="control-label" htmlFor="Name">
                        Name
                    </label>
                    <input
                        className="form-control"
                        type="text"
                        id="Name"
                        name="Name"
                        onChange={this.handleInputChange}
                        value={this.state.Name}
                        data-val="true"
                        date-val-required="Please enter a name"
                    />
                    <span
                        className="text-danger field-validation-valid"
                        data-valmsg-for="Name"
                        data-valmsg-replace="true"
                    />
                </div>
                <div className="form-group">
                    <label className="control-label" htmlFor="Category">
                        Category
                    </label>
                    <input
                        className="form-control"
                        type="text"
                        id="Category"
                        name="Category"
                        onChange={this.handleInputChange}
                        value={this.state.Category}
                    />
                    <span
                        className="text-danger field-validation-valid"
                        data-valmsg-for="Category"
                        data-valmsg-replace="true"
                    />
                </div>
                <div className="form-group">
                    <button className="btn btn-primary">Submit</button>
                </div>
                <Validation />
            </form>

        );
    }
}

export default UpdateProduct;
