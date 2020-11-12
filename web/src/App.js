import React, { useState, useEffect } from 'react';
import './App.css';
// import ExpenseList from './components/ExpenseList';
import uuid from "uuid/v4";
import Alert from './components/Alert'
import Form from './components/Form';
import List from './components/List';

const initialExpenses = localStorage.getItem("items") ? JSON.parse(localStorage.getItem("items")) : []

function App() {

  const [items, setItems] = useState(initialExpenses);
  const [name, setName] = useState('');
  const [amount, setAmount] = useState('');
  const [category, setCategory] = useState('');
  const [alert, setAlert] = useState({ show: false })
  const [edit, setEdit] = useState(false);
  const [id, setId] = useState(0)


  useEffect(() => {
    localStorage.setItem("items", JSON.stringify(items));
  }, [items])
  
  const handleName = e => {
    setName(e.target.value)
  }
  const handleAmount = e => {
    const amount = e.target.value
    if (amount >= 0) {
      setAmount(e.target.value)
    } else {
      handleAlert({ type: "danger", text: `Invalid Item's Amount Input!` });
    }
  }
  const handleCategory = selectedOption => {
    setCategory(selectedOption)
  }
  const handleAlert = ({ type, text }) => {
    setAlert({ show: true, type, text });
    setTimeout(() => { setAlert({ show: false }) }, 3000)
  }
  //handle submit
  const handleSubmit = e => {
    e.preventDefault();
    if (name !== '' && amount > 0) {
      if (edit) {
        let temp= items.map(item => {
          return item.id === id ? { ...item, name, amount, category } : item
        })
        setItems(temp);
        setEdit(false);
        handleAlert({ type: "success", text: "Item edited" });
      }
      else {
        const singleItem = { id: uuid(), name, amount, category };
        setItems([...items, singleItem]);
        handleAlert({ type: "success", text: "Item added" });
      }
      setName("");
      setAmount("");
      setCategory(null);
    } else {
      //handle alert called
      handleAlert({ type: "danger", text: `Item's name can't be empty and the amount has to be higher than 0` });
    }
  }

  //clear all items 
  const clearItems = () => {
    setItems([]);
    handleAlert({ type: "danger", text: "All items deleted" })
  }
  // handle delete
  const handleDelete = (id) => {
    let temp = items.filter(item => item.id !== id);
    setItems(temp);
    handleAlert({ type: "danger", text: "item deleted" })
  }

  return (
    <div>
      {alert.show && <Alert type={alert.type} text={alert.text} />}

      <h1>Contents Limit Insurance</h1>
      <main className="App">
        <Form name={name} amount={amount} category={category} edit={edit} handleAmount={handleAmount} handleName={handleName} handleCategory={handleCategory} handleSubmit={handleSubmit} />
        <List items={items} clearItems={clearItems} handleDelete={handleDelete} />
      </main>
      <h1>
        total :<span className="total">
          ${items.reduce((acc, curr) => { return (acc += parseInt(curr.amount)) }, 0)}
        </span>
      </h1>



    </div>
  );
}

export default App;
