  
import React, { useState, useEffect} from 'react';
import axios from 'axios'; 
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';

function ModalShowAddProject(props) {
  const [project, setProject] = useState({
    name: '',
    description: '',
    deadLine: '',
    categoryId: 1, 
    priorityId: 1, 
    statusId: 1, 
  });



  const [categories, setCategories] = useState([]);
  const [priorities, setPriorities] = useState([]);
  
  useEffect(() => {
    // Загрузка списка категорий с сервера
    axios.get('https://localhost:7182/api/Category')
      .then((response) => {
        setCategories(response.data);
      })
      .catch((error) => {
        console.error('Ошибка при загрузке категорий:', error);
      });
  
    // Загрузка списка приоритетов с сервера
    axios.get('https://localhost:7182/api/Priority')
      .then((response) => {
        setPriorities(response.data);
      })
      .catch((error) => {
        console.error('Ошибка при загрузке приоритетов:', error);
      });
  }, []);
  

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setProject({ ...project, [name]: value });
  };

  const handleSubmit = () => {
    // Создаем объект с данными проекта для отправки на сервер
    const projectData = {
      name: project.name,
      description: project.description,
      deadLine: project.deadLine,
      categoryId: project.categoryId,
      priorityId: project.priorityId,
      statusId: project.statusId,
    };
  
    // Отправляем данные на сервер с помощью Axios
    axios.post('https://localhost:7182/api/Project', projectData)
    .then((response) => {
      axios.get('https://localhost:7182/api/Status')
        .then((response) => {
          const transformedData = response.data.map(status => ({
            id: status.id,
            name: status.name,
            description: status.description,
            projects: status.projects.map(project => ({
              id: project.id,
              isDeleted: project.isDeleted,
              name: project.name,
              description: project.description,
              deadLine: project.deadLine,
              categoryId: project.categoryId,
              statusId: project.statusId,
              priorityId: project.priorityId,
              chatId: project.chatId,
              category: project.category,
              status: project.status,
              priority: project.priority,
              chat: project.chat,
              users: project.users,
              tasks: project.tasks,
            }))
          }));
          props.updateProjects();
        })
        .catch((error) => {
          console.error('Ошибка при получении актуального списка проектов:', error);
        });
    })
    .catch((error) => {
      console.error('Ошибка при добавлении проекта:', error);
    });
  props.onHide();
  
  };

  return (
    <Modal {...props} centered>
      <Modal.Header closeButton>
        <Modal.Title>Add Project</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group>
            <Form.Label>Name</Form.Label>
            <Form.Control
              type="text"
              name="name"
              value={project.name}
              onChange={handleInputChange}
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Description</Form.Label>
            <Form.Control
              as="textarea"
              rows={3}
              name="description"
              value={project.description}
              onChange={handleInputChange}
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Category</Form.Label>
            <Form.Select
              name="categoryId"
              value={project.categoryId}
              onChange={handleInputChange}
            >
              {categories.map((category) => (
                <option key={category.id} value={category.id}>
                  {category.name}
                </option>
              ))}
            </Form.Select>
          </Form.Group>
          <Form.Group>
            <Form.Label>Priority</Form.Label>
            <Form.Select
              name="priorityId"
              value={project.priorityId}
              onChange={handleInputChange}
            >
              {priorities.map((priority) => (
                <option key={priority.id} value={priority.id}>
                  {priority.name}
                </option>
              ))}
            </Form.Select>
          </Form.Group>
          <Form.Group>
            <Form.Label>Deadline</Form.Label>
            <Form.Control
              type="date"
              name="deadLine"
              value={project.deadLine}
              onChange={handleInputChange}
            />
          </Form.Group>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={props.onHide}>
          Close
        </Button>
        <Button variant="primary" onClick={handleSubmit}>
          Add Project
        </Button>
      </Modal.Footer>
    </Modal>
  );
  
}

export default ModalShowAddProject;
