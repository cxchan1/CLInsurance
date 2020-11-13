import React, { useState, useEffect } from 'react';
import './App.css';
import Alert from './components/Alert'
import Form from './components/Form';
import List from './components/List';
import axios from 'axios';
import { MdDelete } from 'react-icons/md';

function App() {

  const [items, setItems] = useState([]);
  const [categoryList, setCategoryList] = useState([]);

  const [name, setName] = useState('');
  const [price, setAmount] = useState('');
  const [categoryId, setCategory] = useState('');
  const [alert, setAlert] = useState({ show: false })
  const [edit, setEdit] = useState(false);
  const [id, setId] = useState(0)

  useEffect(() => {
    async function fetchItems() {
    const result = await axios(
      'https://localhost:5001/api/Item',
    );
    setId(result.data.id)
    setItems(result.data)}

    async function fetchCategories() {
      const result = await axios(
        'https://localhost:5001/api/Category',
      );
      setCategoryList(result.data)}

    fetchItems();
    fetchCategories();
  },[items])
   
  const handleName = e => {
    setName(e.target.value)
  }
  const handleAmount = e => {
    const price = e.target.value
    if (price >= 0) {
      setAmount(e.target.value)
    } else {
      handleAlert({ type: "danger", text: `Invalid Item's Price Input!` });
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
    if (name !== '' && price > 0) {
      if (!edit) {
        async function createItem() {
          await axios({
            method: 'post',
            url: 'https://localhost:5001/api/Item/',
            data: {
              Name: name,
              Price: parseFloat(price),
              CategoryId: categoryId.value
            }
        })};
        createItem()
        handleAlert({ type: "success", text: "Item added" });
      }
      setName("");
      setAmount("");
      setCategory(null);
    } else {
      //handle alert called
      handleAlert({ type: "danger", text: `Item's name can't be empty and the price has to be higher than 0` });
    }
  }

  //clear all items 
  const clearItems = () => {
    if(items.length !== 0){
      for(var item in items){
        handleDelete(items[item].id)
      }
    }
    handleAlert({ type: "danger", text: "All items deleted" })
  }
  // handle delete
  const handleDelete = (id) => {
    async function deletedItem() {
      await axios({
        method: 'delete',
        url: 'https://localhost:5001/api/Item/' + id,
    })};
    deletedItem();
    let temp = items.filter(item => item.id !== id);
    setItems(temp);
    handleAlert({ type: "danger", text: "item deleted" })
  }

  return (
    <div>
      {alert.show && <Alert type={alert.type} text={alert.text} />}

      <h1>Contents Limit Insurance</h1>
      <main className="App">
        <Form name={name} amount={price} category={categoryId} list={categoryList} edit={edit} handleAmount={handleAmount} handleName={handleName} handleCategory={handleCategory} handleSubmit={handleSubmit} />
        {
          categoryList.map(category => {
            var res = items.filter(item => item.categoryId === category.id);
            return <List items={res} category={category.name} handleDelete={handleDelete} />
          })
        }
        <button className="btn" onClick={clearItems}>
          clear Items<MdDelete className="btn-icon" />
        </button>
      </main>
      <h1>
        total :<span className="total">
          ${items.reduce((acc, curr) => { return (acc += parseFloat(curr.price)) }, 0).toFixed(2)}
        </span>
      </h1>
    </div>
  );
}

export default App;
