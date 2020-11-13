import React from 'react';
import Item from './Item';
import '../App.css';

function List({ items, handleDelete, category }) {
    return (
        <>
            <ul className="list">
            {
                items.map(function (item, index){
                    if (index === 0) {
                        return (
                            <div>
                            <li className="header">
                            <div className="info">
                                <span className="expense">{category}</span>
                                <span className="amount">${items.reduce((acc, curr) => { return (acc += parseFloat(curr.price)) }, 0).toFixed(2)}</span>
                            </div>
                            </li>
                            <Item key={item.id} item={item} handleDelete={handleDelete}/>
                            </div>)
                    }else 
                        return <Item key={item.id} item={item} handleDelete={handleDelete}/>
                })
            }
            </ul>

        </>
    )
}

export default List