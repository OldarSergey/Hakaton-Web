import Card from 'react-bootstrap/Card';
import ModalShow from './ModalShow';
import Button from 'react-bootstrap/esm/Button';
import React from 'react';
import axios from 'axios';
import { useEffect, useState } from 'react';

const Project = (props) => {
  const [modalShow, setModalShow] = React.useState(false);
  const [priorityName, setPriorityName] = useState('');

  // Функция для форматирования даты
  const formatDate = (dateString) => {
    const options = { year: 'numeric', month: 'long', day: 'numeric' };
    return new Date(dateString).toLocaleDateString(undefined, options);
  };

  // Запрос к серверу для получения названия приоритета
  useEffect(() => {
    axios.get(`https://localhost:7182/api/Priority/${props.id}`)
      .then((response) => {
        setPriorityName(response.data);
      })
      .catch((error) => {
        console.error('Ошибка при загрузке названия приоритета:', error);
      });
  }, [props.priority]);

  return (
    <div className="card" style={{}}>
        <h6 className="card-subtitle mb-2" style={{marginTop:'5%'}}><strong>{priorityName}</strong></h6>
        <div className="card-body p-3" style={{}}>
        <h5 className="card-title">{props.name}</h5>
        <p className="card-text">{props.description}.</p>
        <p style={{marginRight: '55%'}}> <strong></strong> {formatDate(props.deadLine)}</p>
        </div>
    </div>
  );
};

export default Project;
