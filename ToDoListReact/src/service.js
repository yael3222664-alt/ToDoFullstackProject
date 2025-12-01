import axios from 'axios';

const apiUrl = "http://localhost:5296";

export default {
  getTasks: async () => {
    const result = await axios.get(`${apiUrl}/api/items`);
    return result.data;
  },

  addTask: async(name)=>{
    console.log('addTask', name);
    const result = await axios.post(`${apiUrl}/api/items`, { name, isComplete: false });
    return result.data;
  },

  setCompleted: async(id, isComplete)=>{
    console.log('setCompleted', {id, isComplete});
    // Fetch current item to preserve its name
    const { data: current } = await axios.get(`${apiUrl}/api/items/${id}`);
    await axios.put(`${apiUrl}/api/items/${id}`, { name: current?.name ?? '', isComplete });
    return { id, isComplete };
  },

  deleteTask:async(id)=>{
    console.log('deleteTask', id);
    try {
      await axios.delete(`${apiUrl}/api/items/${id}`);
    } catch (err) {
      if (err?.response?.status === 404) {
        // Already deleted or not found; treat as success for idempotency
        return;
      }
      throw err;
    }
  }
};
