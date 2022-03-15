import React, { Component } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

class Table extends Component {
  constructor(props) {
    super(props);
  }

  DeleteStudent = () => {
    axios
      .delete(
        "https://localhost:44346/api/Student/Deletestudent?Id=" +
          this.props.obj.Id
      )
      .then((json) => {
        if (json.data.Status === "Delete") {
          alert("Record deleted successfully!!");
        }
      });
  };
  render() {
    return (
      <tr>
        {/* <td>{this.props.obj.Name}</td>
        <td>{this.props.obj.RollNo}</td>
        <td>{this.props.obj.Class}</td>
        <td>{this.props.obj.Address}</td>
        <td>
          <Link to={"/edit/" + this.props.obj.Id} className="btn btn-success">
            Edit
          </Link>
        </td>
        <td>
          <button type="button" onClick={this.DeleteStudent} className="btn btn-danger" >
            Delete
          </button>
        </td> */}
        <td>Dhruv</td>
        <td>10</td>
        <td>A</td>
        <td>India</td>
        <td>
          <Link className="btn btn-success">
            Edit
          </Link>
        </td>
        <td>
          <button type="button" className="btn btn-danger" >
            Delete
          </button>
        </td>
      </tr>
    );
  }
}

export default Table;

